   M S B A M L   `   `   `  ����D  @DashBoard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:DashBoard	DashBoard  5   	   (    "DashBoard.UserControl_MyGanttChart   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:DashBoard     5   	   -   5        $��UserControl_GanttChart��5   2   .��5	      (�   (� Stretch$
  Fill=�6   .��5
   
   � 
�������$	��320��6"   $	��430��6/    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ 	#FFCACACA��6#    � RowDefinitions 5      �� 5      $��* �6    �� 5      $	��10* �6    .+�5      ��  �� Orientation$ 
Horizontal=�6   $��20,5,5,5q�63   $
��Left=�6E   $��Center=�6`   .+�5      �� $��Project:��6   $��8(�6+   $
��Left=�68   $��0,0,0,0q�6S   $��Center=�6d   (� 5      $
��Left=�6   $��5,0,0,0q�65   $��Center=�6F   $
  Fill=�6b   $��15��6q   .��5      �� -   5         ��Name$ ProjectsComboBox��5      $��20��6n   $	��120��6z   ��5      �� 5      .R�5   "   �� ��61   �� *Name+6L   5      5      5      �� 5      $��
Time View:��6   $��8(�6-   $
��Left=�6:   $��20,0,0,0q�6U   $��Center=�6g   (� 5      $
��Left=�6   $��5,0,0,0q�65   $��Center=�6F   $
  Fill=�6b   $��15��6q   .��5      �� -   5        $ TimeViewComboBox��5      $��20��6n   $	��120��6z   5       5$      (� 5%      $��
10,0,10,10q�6   $��1��6*   $
  Fill=�67   .��5&      7  1System.Windows.Forms.Integration.WindowsFormsHost  -   5          Name$ 	GanttHost��5&   #   $	��281��66   $	��410��6C   5(      5*      5+      5,      