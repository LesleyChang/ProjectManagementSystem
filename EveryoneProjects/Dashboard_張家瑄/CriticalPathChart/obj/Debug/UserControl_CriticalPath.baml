   M S B A M L   `   `   `  ����L  HCriticalPathChart, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:CriticalPathChartCriticalPathChart  5   	   0    *CriticalPathChart.UserControl_CriticalPath   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:CriticalPathChart     5   	   -   5        $��
CPM_Window��5   "   $	��450��6	   $	��800��6     � 	Resources  5	         WorkItem �� Orientation  ColumnTemplate  TaskItemTemplate �� DataType��%�  &	        &	 %    7   &	 �    �� 5   
   .R�5      �� $��Center=�6   $��1q�62   $	��Top=�6F   
����  �._�5      �� $ Vertical=�6   .+�5      �� $��Center=�66   $��2q�6S   ��6    �� *Name+6S   �� 5      $��Duration��6    $��Center=�60   $��2q�6M   5      5      5      �� 5   
   .R�5      �� ��6   �� ��5      �� 5      .R�5      �� $ Vertical=�6%   5      ��5      �� 5      .R�5      �� 8��  ��6U   �� *Items+5      5       5!      �� 5"   
   $ ContentControl��60   .R�5#      �� ���	#FFA8A7A7$��1q�6-   ._�5$      �� .+�5%      �� $��	NameBlock��6    $��2q�61   $
��Name��6<   
���   �$��Center=�6[   $��Center=�6x   �� 5&      $��DurationBlock��6    $��2q�65   $��Duration��6@   
���   �$��Center=�6c   $��Center=�6�   5'      5(      5)      5*      .��5,      (�  (� Stretch$
 Fill=�6   .��5-   
   �� -   5        $��
MainCanvas��5-      $	��400��6#   $	��800��60   .+�5.      �� -   5        $��
StartBlock��5.      $
��auto��6'   $��1q�64   $
��auto��6H   $��Right=�6V   $��Center=�6r   
���   � �� Left$ 19��6�   
 �� Top$	 182��6�   ._�5/      �� $��Start��6   $��10q�6)   50      �� 51      -   5        $��EndBlock��51      $
��auto��6%   $��1q�62   $
��auto��6F   $
��Left=�6T   $��Center=�6o   
���   �$	 734��6�   $	 182��6�   ._�52      �� $	��End��6   $��10q�6'   53      54      55      56      