   M S B A M L   `   `   `  ����J  FWpf_LoginSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Wpf_LoginSystemWpf_LoginSystem  5   	        Wpf_LoginSystem.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Wpf_LoginSystem     5   	     � Title$  會員登入��5   	   $	��450��6   $	��800��6#   .��5	      (�  (� Stretch$
 Fill=�6   .��5
   
   � $	��417��6   $	��792��6    � RowDefinitions 5      �� 5      $
��260* �6    �� 5      $
��100* �6    �� 5      $	��57* �6    .+�5      �� $
��Left=�6   $	��170��6/   $��
315,45,0,0q�6<   $	��Top=�6P   $	��170��6h   $3��-/Wpf_LoginSystem;component/Images/60Lemon.png��6t   �� 5      $��162,19,153,20q�6   $��1��6,   .+�5      �� $
��Left=�6   $
��Wrap=�67   $��使用者名稱：��6K   $	��Top=�6Y   $��22��6q   $��90��6}   
 �� Top$ 1��6�   �� 5      $
��Left=�6   $
��Wrap=�67   $��	密碼：��6K   $	��Top=�6V   $��22��6n   $��45��6z   $ 39��6�   �� 5      -   5        $��tb_ID��5      $
��Left=�6'   $��23��6B    �� TextWrapping$
 Wrap=�6N   $	��Top=�6b   $	��260��6z    �� Left$	 108��6�   �� 5      -   5        $��tb_PW��5      $
��Left=�6'   $��23��6B   $
 Wrap=�6N   $	��Top=�6b   $	��260��6z   $	 108��6�   $ 38��6�   �� 5      -   5        $��登入��5      $
��Left=�6&   $	��Top=�6A   $��75��6Y   
�������$��26��6w   $	 403��6�   $ 19��6�   6�   5      �� 5      $��2��6    �� Orientation$ 
Horizontal=�6&   $��Center=�6?   $��Center=�6\   .+�5      �� -   5        $��還沒有帳號��5      $
��Left=�6)   $	��Top=�6D   $��90��6\   
�������$��26��6z   $��
0,10,20,10q�6�   6�   �� 5      -   5        $��忘記密碼��5      $
��Left=�6(   $	��Top=�6C   $��90��6[   
�������$��26��6y   $��
20,10,0,10q�6�   6�   5      5      5      5      