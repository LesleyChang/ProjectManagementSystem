   M S B A M L   `   `   `  ����P  LProjectSystemCalendar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ProjectSystemCalendarProjectSystemCalendar  5   	   #    ProjectSystemCalendar.AddPlan   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:ProjectSystemCalendar     5   	     � Title$  我的行事曆��5   	   $��420.388��6   $��427.774��6)   .��5	      � $��0,0,-0.4,0.4q�6    � RowDefinitions 5
   
   �� 5      $	��44* �6   �� 5      $	��66* �6   �� 5      $	��60* �6   �� 5      $	��60* �6   �� 5      $
��143* �6   .+�5   
   �� $��儲存��6   $��18(�6   $��83��6,   $
��Left=�67   ��6R   Z� ��6h   Z� �� 5   
   $��刪除��6   $��18(�6   $��83��6,   $
��Left=�67   $��88,0,0,0q�6   ��6R   Z� ��6h   Z� 6   o� 5   
   $��Right=�6   $��	0,0,0.6,0q�6+   $	��252��6>   .@�5      m� $��20(�6D   $��
分類 ∨��6R   $��44��6`   $
��Left=�6l   $	��252��6�   ��6   Z� ��6.   Z� .@�5      m� $��紅色分類��6   
���  ��$��15(�6:   m� 5      $��橘色分類��6   
��� ���$��15(�6=   m� 5      $��黃色分類��6   ���	#FFEEF007$��15(�6@   m� 5      $��綠色分類��6   
��� � �$��15(�6=   m� 5      $��藍色分類��6   ���	#FF009DCD$��15(�6A   m� 5      $��紫色分類��6   ���	#FF9900FF$��15(�6A   5      5      �� 5   
   $��4��6   $��20q�6    �� TextWrapping$
 Wrap=�6+   $��新增描述��6?   �� 5    
   $��40(�6   $��10q�6    $��1��6,   $
 Wrap=�69   $��新增標題��6M   ��6Y   Z� ��6o   Z� (  "System.Windows.Controls.DatePicker  5!   
   $
��Left=�6   $��22,16.4,0,0q�60   $��2��6E   $	��Top=�6R   $	��216��6j     5"   
   $
��Left=�6   $��22,19.2,0,0q�60   $��3��6E   $	��Top=�6R   $	��216��6j   5$      5%      