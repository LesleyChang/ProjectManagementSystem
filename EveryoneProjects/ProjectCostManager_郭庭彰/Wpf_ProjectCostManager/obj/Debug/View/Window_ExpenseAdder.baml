   M S B A M L   `   `   `  ����Q  MWpf_ProjectCostManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:Wpf_ProjectCostManager.ViewWpf_ProjectCostManager.View  5   	   ]3clr-namespace:Wpf_ProjectCostManager.MyUserControls%Wpf_ProjectCostManager.MyUserControls  5   	   5    /Wpf_ProjectCostManager.View.Window_ExpenseAdder   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:Wpf_ProjectCostManager.View     5   	   NMyUserControls3clr-namespace:Wpf_ProjectCostManager.MyUserControls     5   	     � 
ResizeMode$  NoResize=�5	   	    � Title$ Window_AddRxpense��5
   	   $	��450��6#   $
��1000��60   .��5      (�  (� Stretch$
 Fill=�6   .��5   
   � ���	#FF404040$
��auto��6&   $
��auto��64   .+�5      �� $��10,10,10,52q�6    �� Orientation$ Vertical=�6.   .+�5      �� -   5         ��Name$ 	sp_Column��5      $ 
Horizontal=�60   $
��Left=�6I   $��40��6d   $	��Top=�6p   $	��974��6�   .+�5      �� -   5        $
��Left=�5      $��30��68   $��日期��6D   $	��Top=�6Q   $	��120��6i   $��0q�6u   
����� �
�������$��Center=�6�   6�   �� 5      $
��Left=�6   $��30��68   $��任務名稱��6D   $	��Top=�6S   $	��120��6k   $��5,0,0,0q�6w   
����� �
�������$��Center=�6�   �� 5      $
��Left=�6   $��30��68   $��費用名稱��6D   $	��Top=�6S   $	��120��6k   $��5,0,0,0q�6w   
����� �
�������$��Center=�6�   �� 5      -   5        $
��Left=�5      $��30��68   $��費用類別��6D   $	��Top=�6S   $	��120��6k   $��5,0,0,0q�6x   
����� �
�������$��Center=�6�   6�   �� 5      $
��Left=�6   $��30��68   $��數量��6D   $	��Top=�6Q   $	��100��6i   $��5,0,0,0q�6u   
����� �
�������$��Center=�6�   �� 5      $
��Left=�6   $��30��68   $��單位��6D   $	��Top=�6Q   $��50��6i   $��5,0,0,0q�6t   
����� �
�������$��Center=�6�   �� 5      $
��Left=�6   $��30��68   $��單價��6D   $	��Top=�6Q   $	��100��6i   $��5,0,0,0q�6u   
����� �
�������$��Center=�6�   �� 5      $
��Left=�6   $��30��68   $��小計��6D   $	��Top=�6Q   $	��100��6i   $��5,0,0,0q�6u   
����� �
�������$��Center=�6�   5      �� 5      $
��Auto=�6   $
��Left=�6B   $	��317��6]   .��5      �� -   5        $ sp_Resources��5   !   $
��auto��67   $
��auto��6E   .+�5      7   1Wpf_ProjectCostManager.MyUserControls.UC_Resource  -   5          Name$ 	Resource1��5   5   7   1Wpf_ProjectCostManager.MyUserControls.UC_Resource   Loaded$ Resource1_Loaded��6H   5      5      5      �� 5      -   5        $��OK��5      $
��Left=�6"   $��775,372,0,0q�6=   $	��Top=�6R   $��75��6j   6u   �� 5      -   5        $��Cancel��5      $
��Left=�6&   $��882,372,0,0q�6A   $	��Top=�6V   $��75��6n   6y   5       5!      5"      