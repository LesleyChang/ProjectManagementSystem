   M S B A M L   `   `   `  ����A  =Trello, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:TrelloTrello  5   	       Trello.TrelloPage   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Trello     5   	   -   5          � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      (�  (� Stretch$ Uniform=�6   .��5
   
   � $	��419��6   $	��792��6    � RowDefinitions 5      �� 5      $	��36* �6    �� 5      $
��383* �6     � ColumnDefinitions 5      �� 5      $
��113* �6#   �� 5      $
��300* �6#   �� 5      $
��379* �6#   .+�5      R� -   5         R�Name$
 menu��5      $��2��6'   $��0,0,1.985,-0.292q�68   ��5      �� 5       �� DataType$$ x:Type Trello:propertyNodeItem��6/    �� ItemsSource 6Y   �� *
Children+.R�5      ��  �� Orientation$ 
Horizontal=�6%   .+�5      �� -   5        $��Center=�5   ^   $��	0,10,0,10q�6�   ��6y   �� *DisplayName+6�   5      5      5      �� 5      -   5         ��Name$ Win_ContentControl��5      $��1��6:   $��2��6J   $��0.015,36,-0.369,-0.292q�6^   $��2��6~   �� 5      -   5        $��win_projectName��5      $
��Left=�6+   $��Bottom=�6M   $��20(�6o   $��1��6~   $��10.015,0,3.8,0.185q�6�   5      5       5!      