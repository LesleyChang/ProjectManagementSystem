   M S B A M L   `   `   `  ����D  @DashBoard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:DashBoard	DashBoard  5   	   %    DashBoard.OverviewDashboardPage   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:DashBoard     5   	   -   5          � Title$  	Dashboard��5   	   $	��800��6   $
��1200��6(    � 	Resources 5	         ContentTemplate_Check �� DataType J� RenderTransformOrigin �� Angle  ContentTemplate_Pencil  ContentTemplate_Plus��%L  &	        &	 >    &	 �    �� 5
   
   $ Content��65   .R�5      � $��Center=�6   $��12��60   $	��Top=�6=   $��5q�6U   $��20��6`   $ 0.5,0.5&�6k   z�5      V� 5      .~�5      �� �� 5      �� 5      $	 135Q�6*   T� 5      5      .+�5      �� 
�������$��0,5,5,0q�61   5      5      �� 5   
   .R�5      �� $��Images/icons_pencil.png��6   $
��Fill=�65   $��20��6D   $��20��6O   6^   5      �� 5   
   .R�5      �� $��Images/plus.png��6   $
��Fill=�6-   $��20��6<   $��20��6G   6V   5      5      .��5       � -   5        $��WholePageGrid��5       .+�5"   
   �� $
��Auto=�6   $
��Auto=�6:   .��5#      �� -   5         ��Name$ 
MainCanvas��5#      $��0,0,0,0q�6)   ���	#FFE5F3FF$
��auto��6Q   $
��auto��6^    J� 	AllowDrop . 5&      5'      �� 5)   
   -   5         ��Name$ AddControl_Btn��5)      $��Right=�6*   $��50��6F   $��0,0,9.6,10.4q�6R   $��Bottom=�6h   #��[ 5*      
�������$��20(�6l   $��50��6z   ���	#FFCA6969$��1��6�    J� Effect 5+      3  -System.Windows.Media.Effects.DropShadowEffect  5,      	   Color$	 	#FFCACACA��6#   ��5.      �� 5/      
 �� 
TargetType"
 ��6"   .R�50      � .+�51      F�  �� Stretch$ Uniform=�6    � UseLayoutRounding .  ���	#FF2C9A49��52      @� 53   "    @� RadiusX$ 1Q�62    @� RadiusY$ 1Q�6>   55      �� 56      $��Center=�6+   $��Center=�6H   57      58      5:      �� 5<   
   -   5        $ Modified_Btn��5<      $��Right=�6(   $��50��6D   $��0,0,9.6,10.4q�6P   $��Bottom=�6f   #��[ 5=      $��50��6K   ���	#FFCA6969$��12(�6n    � ToolTip$ 編輯儀錶板��5>      $��1��6<    5?        5@      $	 	#FFCACACA��6#   ��5B      �� 5C      "
 ��6"   .R�5D      � .+�5E      F� $ Uniform=�6    .  ���	#FF1FB3FF��5F      @� 5G   "   $ 1Q�62   $ 1Q�6>   5I      �� 5J      $��Center=�6+   $��Center=�6H   5K      5L      5N      5P      5Q      