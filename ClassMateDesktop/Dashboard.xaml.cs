using ClassMateDesktop.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;

namespace ClassMateDesktop
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {

        private Connector connector;

        private List<ClassRoom> classRoomList;
        private List<Feedback> feedbackList;
        private List<Question> questionList;

        private Lecture lecture;
        private String currentClassId;

        private ObservableValue goodValue;
        private ObservableValue badValue;
        private ObservableValue neutralValue;

        public Dashboard()
        {
            InitializeComponent();

            goodValue = new ObservableValue(0);
            badValue = new ObservableValue(0);
            neutralValue = new ObservableValue(0);

            goodOne.Values = new ChartValues<ObservableValue> { goodValue };
            badOne.Values = new ChartValues<ObservableValue> { badValue };
            neutralOne.Values = new ChartValues<ObservableValue> { neutralValue };

            PointLabel = chartPoint =>
                string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);
            DataContext = this;


            connector = new Connector();
            updateClassList();
            Thread thread = new Thread(new ThreadStart(sync));
            thread.Start();
        }

        public Func<ChartPoint, string> PointLabel { get; set; }

        private void Chart_OnDataClick(object sender, ChartPoint chartpoint)
        {
            var chart = (LiveCharts.Wpf.PieChart)chartpoint.ChartView;

            //clear selected slice.
            foreach (PieSeries series in chart.Series)
                series.PushOut = 0;

            var selectedSeries = (PieSeries)chartpoint.SeriesView;
            selectedSeries.PushOut = 8;
        }

        public delegate void UpdateData();

        private void sync()
        {
            while (true)
            {
                label.Dispatcher.Invoke(
                    new UpdateData(updateDetails), new object[] { });
                

               // updateDetails();
               // Console.WriteLine("Hello Wolrd");
                Thread.Sleep(10000);
            }
            
            
        }

        private void updateClassList()
        {
            classRoomList=connector.getClasses(Manager.getInstance().getToken());

            foreach(ClassRoom classRoom in classRoomList)
            {
                comboBox.Items.Add(classRoom.name);
            }

            comboBox.SelectedItem = classRoomList[0].name;


        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            updateDetails();
        }

        private void updateDetails()
        {
            Console.WriteLine("*****Update details******");
            foreach (ClassRoom classRoom in classRoomList)
            {
                if (classRoom.name.Equals(comboBox.SelectedValue))
                {

                    currentClassId = classRoom._id;
                    List<Lecture> lectureList = connector.getLectures(Manager.getInstance().getToken(), currentClassId);
                    lecture = lectureList[lectureList.Count - 1];
                    feedbackList = lecture.feedbacks;
                    questionList = lecture.questions;
                    feedbackListView.Items.Clear();

                    badValue.Value = 0;
                    goodValue.Value = 0;
                    neutralValue.Value = 0;


                    foreach (Feedback f in feedbackList)
                    {

                        StackPanel l = new StackPanel();
                        TextBlock t1 = new TextBlock();
                        TextBlock t2 = new TextBlock();

                        t1.Text = f.details;
                        t2.Text = f.semantic;

                        l.Children.Add(t2);
                        l.Children.Add(t1);

                        feedbackListView.Items.Add(l);

                        if (f.semantic.Equals("bad"))
                        {
                            badValue.Value += 1;
                        }
                        if (f.semantic.Equals("neutral"))
                        {
                            neutralValue.Value += 1;
                        }
                        if (f.semantic.Equals("Good"))
                        {
                            goodValue.Value += 1;
                        }
                    }
                    questionListView.Items.Clear();

                    foreach (Question q in questionList)
                    {
                                                                                             
                        StackPanel l = new StackPanel();
                        l.Tag = q._id;
                        TextBlock t1 = new TextBlock();
                        t1.FontSize = 15;
                        TextBlock t2 = new TextBlock();

                        t1.Text = q.title;             
                        t2.Text = q.details;

                        l.Children.Add(t1);
                        l.Children.Add(t2);

                        questionListView.Items.Add(l);  
                                                                                               
                    }

                }
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string _question = (string)((StackPanel)questionListView.SelectedItem).Tag;
            connector.postAnswer(Manager.getInstance().getToken(), _question, "Answered in the lecture");
        }

    }
}
