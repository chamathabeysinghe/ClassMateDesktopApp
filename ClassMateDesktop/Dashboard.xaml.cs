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

        public Dashboard()
        {
            InitializeComponent();
            connector = new Connector();
            updateClassList();
            Thread thread = new Thread(new ThreadStart(sync));
            thread.Start();
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
