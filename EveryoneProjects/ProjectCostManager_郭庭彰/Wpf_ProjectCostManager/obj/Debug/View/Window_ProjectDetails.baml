   M S B A M L   `   `   `  ����Q  MWpf_ProjectCostManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Wpf_ProjectCostManagerWpf_ProjectCostManager  5   	   Y UDe.TorstenMandelkow.MetroChart, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullwTclr-namespace:De.TorstenMandelkow.MetroChart;assembly=De.TorstenMandelkow.MetroChartDe.TorstenMandelkow.MetroChart 5   	   2    ,Wpf_ProjectCostManager.Window_ProjectDetails   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:Wpf_ProjectCostManager     5   	   fchartTclr-namespace:De.TorstenMandelkow.MetroChart;assembly=De.TorstenMandelkow.MetroChart     5   	   ���	#FF404040  � Title$  Window_ProjectDetails��5
   	   $	��450��6'   $	��800��64   .��5      (�  (� Stretch$
 Fill=�6   .��5   
   � $	��417��6   $	��792��6    � RowDefinitions 5      �� 5      $	��45* �6    �� 5      $
��272* �6    �� 5      $
��100* �6    .+�5      �� 
�������$
��Left=�6+   $
��Wrap=�6F   $��專案ID：��6Z   $	��Top=�6g   $��22��6   $��60��6�   $��	14,10,0,0q�6�   �� 5      -   5         ��Name$ tb_ID��5      $
��Left=�6%   $��23��6@    �� TextWrapping$
 Wrap=�6L   $	��Top=�6`   $	��120��6x   $��	74,10,0,0q�6�    �� 
IsReadOnly . 6�   �� 5      
�������$
��Left=�6+   $
��Wrap=�6F   $��專案名稱：��6Z   $	��Top=�6g   $��22��6   $��75��6�   $��
282,10,0,0q�6�   �� 5      -   5        $ tb_Name��5      $
��Left=�6'   $��23��6B   $
 Wrap=�6N   $	��Top=�6b   $	��120��6z   $��
357,10,0,0q�6�    . 6�   �� 5      
�������$
��Left=�6+   $
��Wrap=�6F   $��需求部門：��6Z   $	��Top=�6g   $��22��6   $��75��6�   $��
561,10,0,0q�6�   �� 5      -   5        $ tb_Department��5      $
��Left=�6-   $��23��6H   $
 Wrap=�6T   $�� ��6h   $	��Top=�6p   $	��120��6�   $��
636,10,0,0q�6�    . 6�   �� 5      
�������$
��Left=�6+   $��	10,10,0,0q�6F   $
��Wrap=�6Y   $��	百分比��6m   $	��Top=�6x   $��2��6�   $��22��6�   $��82��6�   �� 5      
�������$
��Left=�6+   $��	27,37,0,0q�6F   $
��Wrap=�6Y   $��完工比率：��6m   $	��Top=�6z   $��2��6�   $��22��6�   $��87��6�   �� 5      
�������$
��Left=�6+   $��	27,65,0,0q�6F   $
��Wrap=�6Y   $��預算執行率:��6m   $	��Top=�6{   $��2��6�   $��22��6�   $��87��6�   �� 5      
�������$
��Left=�6+   $��
523,10,0,0q�6F   $
��Wrap=�6Z   $��成本��6n   $	��Top=�6x   $��2��6�   $��22��6�   $��82��6�   �� 5      
�������$
��Left=�6+   $��
540,37,0,0q�6F   $
��Wrap=�6Z   $��已投入成本：��6n   $	��Top=�6|   $��2��6�   $��22��6�   $	��100��6�   �� 5       -   5        $ tb_InputCost��5       $
��Left=�6,   $��23��6G   $��
636,36,0,0q�6S   $
 Wrap=�6g   $	��Top=�6{   $	��120��6�   $��2��6�    . 6�   �� 5!      
�������$
��Left=�6+   $��
540,65,0,0q�6F   $
��Wrap=�6Z   $��估計總成本：��6n   $	��Top=�6|   $��2��6�   $��22��6�   $	��100��6�   �� 5"      -   5        $ tb_TotalCost��5"      $
��Left=�6,   $��23��6G   $��
636,64,0,0q�6S   $
 Wrap=�6g   $	��Top=�6{   $	��120��6�   $��2��6�    . 6�   � 5#      -   5         �Name$ progressBar_Complete��5#       � Value$ 50Q�68   ���	#FF439E9E$��114,41,287,45q�6Z   $��2��6q   
�������6�   � 5$      -   5        $ progressBar_Budget��5$      $ 50Q�66   ���	#FFC163C1���	#FFE6E6E6$��114,70,287,16q�6o   $��2��6�   6�   �� 52      $��1��6   .+�53      6  0De.TorstenMandelkow.MetroChart.ClusteredBarChart     
ChartStyle#��[  54   *   .  (De.TorstenMandelkow.MetroChart.ChartBase   
ChartTitle$ Project Costs��55   *   	   ChartSubTitle$ 	 Group by Resource Category��56   *   $	��272��6U   
   Series
 58      0  *De.TorstenMandelkow.MetroChart.ChartSeries     Caption$ Costs��59         DisplayMember$ Category��5:         ValueMember$ Number��5;      ��5<      �� *Costs+5=      5?      5@      �� 5A      -   5         ��Name$ lb_Finished��5A   G   $��Center=�6   $	��50%��68   ���	#FF686A6B$��11(�6s   $
��Left=�6�   $��
292,35,0,0q�6�   $��2��6�   $	��Top=�6�   $��26��6�   �� 5B      -	   5        $ lb_BudgetUsed��5B   F   $��Center=�6   $	��50%��68   ���	#FF686A6B$��11(�6t   $
��Left=�6�   $��
292,64,0,0q�6�   $��2��6�   $	��Top=�6�   $��26��6�   5C      5D      5E      