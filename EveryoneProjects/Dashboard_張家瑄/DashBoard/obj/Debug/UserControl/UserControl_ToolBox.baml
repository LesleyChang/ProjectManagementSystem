   M S B A M L   `   `   `  ����D  @DashBoard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:DashBoard	DashBoard  5      #    DashBoard.UserControl_ToolBox   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:DashBoard     5        � DataContext  5   7   ��  � 	Resources 5	         ItemTemplate � ColumnDefinitions �� TextAlignment��%�  &	        �� 5
   
   .R�5      � $��80��6   $��20,5,5,5q�6   $
��Left=�61   $	��Top=�6L   $	��200��6d    5      �� 5      $	��100 �6'   �� 5      $��30 �6'   �� 5      $��* �6'   .+�5      �� $��Uniform=�65   ��6   �� *	ImagePath+6I   �� 5      $��14(�62   $ Center=�6@   $
��Left=�6W   $��Center=�6r   $��2��6�   $y�Hidden=�6�   ��6   �� *Desc+6�   5      5      5      .��5      (�  (� Stretch$
 Fill=�6   .��5   
   � $	��600��6   $	��250��6   
������� J� RenderTransformOrigin$ 0.5,0.5&�6<    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ 	#FFCACACA��6#      	Direction$	 240Q�65   	 � RowDefinitions	 5      �� 5      $
��0.5* �6    �� 5      $��2* �6    �� 5      $	��10* �6    �� 5       $��2* �6    .+�5"      �� $��1��6   
 �� Orientation$
 Vertical=�6&   $
��Left=�6=   $��Center=�6X   $��15,0,0,0q�6s   .+�5#      �� $��新增 Widget��6   $
��Left=�6,   $��14(�6G   $	��Top=�6U   $��0,0,0,5q�6m   �� 5$      -   5        $��	SearchBox��5$      $	��200��6,   $��20��68   $y�Hidden=�6D   5%      �� 5&      -   5        $��
WidgetList��5&      $��2��6(   ��5'   �   Z� ��5(      �� 5)      .R�5*      � $��80��6   $��15,5,5,5q�6+   $
��Left=�6=   $	��Top=�6X   $	��190��6p    5+      �� 5,   "   $��80 �63   �� 5-   "   $��20 �63   �� 5.   "   $��* �63   .+�51      �� $��Uniform=�6A   ��6$   �� *	ImagePath+6U   �� 52      $��12(�6>   $
 Left=�6L   $
��Left=�6a   $��Center=�6|   $��2��6�   ��6(   �� *Desc+6�   53      54      56      �� 57      -   5        $��CloseBtn��57      $��Close��6%   $��3��66   $��0,0,20,0q�6C   $��Right=�6U   $��Center=�6q   $��75��6�   $��30��6�   ��6�   Z� ��6�   Z� 59      5;      5=      