   M S B A M L   `   `   `  ����p  lSystem.Windows.Controls.DataVisualization.Toolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=null�rclr-namespace:System.Windows.Controls.DataVisualization;assembly=System.Windows.Controls.DataVisualization.Toolkit)System.Windows.Controls.DataVisualization  5   	   �{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit2System.Windows.Controls.DataVisualization.Charting  5   	   E AAssignTask, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:AssignTask
AssignTask 5   	      AssignTask.EmployeeDetail   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   �DVrclr-namespace:System.Windows.Controls.DataVisualization;assembly=System.Windows.Controls.DataVisualization.Toolkit     5   	   �DVC{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit     5   	   *localclr-namespace:AssignTask     5   	     � Title$  EmployeeDetail��5
   	   $	��536��6    $	��300��6-   .��5      (�  (� Stretch$
 Fill=�6   .��5   
   � $	��505��6   $	��292��6   .+�5      �� -   5         ��Name$ employeePic��5      $
��Left=�6)   $��90��6D   $��	14,19,0,0q�6P   $	��Top=�6c   $��89��6{   �� 5      -   5        $ employeeName��5      $��Label��6*   $
��Left=�6:   $��
171,24,0,0q�6U   $	��Top=�6i   $	��115��6�   �� 5      -   5        $ employeeName_Title��5      $��員工姓名: ��60   $
��Left=�6A   $��
108,24,0,0q�6\   $	��Top=�6p   $��63��6�   �� 5      -   5        $ employeeID_Title��5      $��員工編號: ��6.   $
��Left=�6?   $��
108,54,0,0q�6Z   $	��Top=�6n   $��63��6�   �� 5      -   5        $ employeeSkill_Title��5      $��專長等級: ��61   $
��Left=�6B   $��
108,85,0,0q�6]   $	��Top=�6q   $��63��6�   �� 5      -   5        $ 
employeeID��5      $��Label��6(   $
��Left=�68   $��
171,54,0,0q�6S   $	��Top=�6g   $��98��6   �� 5      -   5        $ employeeSkill��5      $��Label��6+   $
��Left=�6;   $��
171,85,0,0q�6V   $	��Top=�6j   $��98��6�   
���  ��6�   &   System.Windows.Controls.DataGrid  5      -   5          Name$ grid1��5      $
��Left=�6'   $	��182��6B   $��	0,138,0,0q�6O   $	��Top=�6b   $	��292��6z      GridLinesVisibility$ Vertical=�6�      
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 目前承接工作��6B      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6R   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6)   �� *Task+6R     5      $ 狀態��6H   $ 50 6T   	 6)   �� *
TaskStatus+6T     5      $ 預計耗工時��6I   $	 100 6X   	 6)   �� *EstWorkTime+6X   5      � 5      -	   5        
 �Name$
 workloadBar1��5      $
��Left=�60   $��26��6K   $��108,343,0,0q�6W   $	��Top=�6l   $	��156��6�    � Maximum$	 100Q�6�    � Minimum$ 0Q�6�    � Value$ 20Q�6�   �� 5      $��工作負荷��6   $
��Left=�6#   $��
18,344,0,0q�6>   $	��Top=�6R    J� RenderTransformOrigin$ 
0.775,0.36&�6j   �� 5      -
   5        $ barValueLabel��5      $��Label��6+   $
��Left=�6;   $��171,345,0,0q�6V   $	��Top=�6k    J� Opacity$	 0.3Q�6�   �� 5      $��總消耗工時��6   $
��Left=�6$   $��
18,387,0,0q�6?   $	��Top=�6S   $ 
0.775,0.36&�6k   �� 5      -   5        $��worktimeSumLabel1��5      $��0��6.   $
��Left=�6:   $��108,387,0,0q�6U   $	��Top=�6j   $ 
0.775,0.36&�6�   5       5!      5"      