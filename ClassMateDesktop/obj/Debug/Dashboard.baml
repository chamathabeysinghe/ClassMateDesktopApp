   M S B A M L   `   `   `  ����K  GClassMateDesktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:ClassMateDesktopClassMateDesktop  5   	   U QLiveCharts.Wpf, Version=0.9.6.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5   	        ClassMateDesktop.Dashboard   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:ClassMateDesktop     5   	   Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5   	   -   5          � Title$  	Dashboard��5
   	   $��645.801��6   $��1205.066��6,    � WindowStyle$
 None=�6=    � AllowsTransparency .  � WindowStartupLocation$ CenterScreen=�6j   ���	#FFEDEBEB.��5      � .+�5   
   �� -   5         ��Name$ label��5      $��Current Class��6   $
��Left=�67   $��
351,92,0,0q�6R   $	��Top=�6f    J� RenderTransformOrigin$ -1.829,-0.272&�6~   $	��128��6�   �� 5   
   -   5         ��Name$ comboBox��5      $
��Left=�6%   $��
513,92,0,0q�6@   $	��Top=�6T   $	��603��6l   $��25��6x   6�   �� 5   
   ���	#FF3A3A46$
��Left=�6%   $��579.801��6@   $��0,66,0,0q�6Q   $	��Top=�6c   $	��297��6{   �� 5   
   -   5         ��Name$ questionListView��5      $
��Left=�6-   $��343.2��6H   $��321,130,0,0q�6W   $	��Top=�6l   $	��505��6�    � 	Resources 5      	 �� 
TargetType
 �� Property �� Value��%Y   '��       �� 5      "	 ��6   .�5      �� 
 � y�$ 	Collapsed=�63   5      5       �� View 5      �� 5      .P�5      �� 5      5      �� 5   
   -   5        $ feedbackListView��5      $
��Left=�6-   $	��216��6H   $��853,130,0,0q�6U   $	��Top=�6j   $��323.5��6�    5      ��%Y   '��       �� 5      "	 ��6   .�5      �� 
 � y�$ 	Collapsed=�63   5      5        5!      �� 5"      .P�5#      �� 5$      5&      �� 5'   
   -   5         ��Name$ button��5'      $��Mark As Answered��6!   $
��Left=�6<   $��321,495.2,0,0q�6W   $	��Top=�6n   $	��185��6�   $
��51.4��6�   ���	#FF2BB4F0
�������$��17.333(�6  ��6  Z�   LiveCharts.Wpf.PieChart  5(   
   -   5          Name$ pieChart��5(      &   LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$ Bottom=�6)      	Hoverable .  $��849,359,21.8,22.6q�6�      DataTooltip 6q   Z�    Series 5*        LiveCharts.Wpf.PieSeries  -   5          Name$ goodOne��5*         LiveCharts.Wpf.Series   Title$
 Good��61      Values;  5LiveCharts.Wpf.Converters.NumericChartValuesConverter$ 1 6>      
DataLabels .    
LabelPoint 5+       �� *
PointLabel+  5,      -	   5        $ badOne��5,       $	 Bad��60   $ 1 6<    .  5-       �� *
PointLabel+  5.      -
   5        $ 
neutralOne��5.       $ Neutral��64   $ 1 6D    .  5/       �� *
PointLabel+52      �� 53   
   $
��66.4��6   $��297,-0.4,0,0q�6"   $	��Top=�68   
�������6P   �� 54   
   ���	#FFEB741A$
��Left=�6%   $��66��6@   $	��Top=�6L   $	��297��6d   �� 55   
   -   5         ��Name$ image��55   /   $��Right=�6>   $
��36.4��6Z   $��0,12,28.566,0q�6h   $	��Top=�6   $
��42.4��6�   $ ��ic_close_black_24dp_2x.png��6�    � Cursor$
 Hand��6�   �� 56   
   -   5         ��Name$ 	textBlock��56      $��66��6'   $��41.964,4,0,0q�63   $
��Wrap=�6I   $	��Top=�6]   $��40(�6u   
�������$
��Left=�6�   $��282.036��6�   �� 6�   $�Class��6�   �� 6�   $
��Bold"�6�   $
�MATE��6�   6�   �� 57   
   -   5        $ 
textBlock1��57      $
��Left=�6(   $
��54.8��6C   $��	70,92,0,0q�6Q   $
��Wrap=�6d   $��	Dashboard��6x   $	��Top=�6�   $��121.2��6�   ���	#FFD8DAD9$��18.667(�6�   $��Segoe UI Emoji)�6�   �� 58   
   -   5        $ textBlock1_Copy��58      $
��Left=�6-   $
��54.8��6H   $��73.2,144.8,0,0q�6V   $
��Wrap=�6n   $
��Help��6�   $	��Top=�6�   $��121.2��6�   ���	#FFD8DAD9$��18.667(�6�   $��Segoe UI Emoji)�6�   �� 59   
   -   5        $ textBlock1_Copy1��59      $
��Left=�6.   $
��54.8��6I   $��70,199.6,0,0q�6W   $
��Wrap=�6m   $��
Contact Us��6�   $	��Top=�6�   $��121.2��6�   ���	#FFD8DAD9$��18.667(�6�   $��Segoe UI Emoji)�6�   �� 5:   
   ���	#FF5B5B62$
��Left=�6%   $��	0,130,0,0q�6@   $	��297��6S    J� Opacity$	 0.5Q�6_   $��381.401��6m   $	��Top=�6~   5;      5<      