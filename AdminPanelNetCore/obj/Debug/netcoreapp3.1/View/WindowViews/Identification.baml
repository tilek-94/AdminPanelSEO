   M S B A M L   `   `   `  ����L  HAdminPanelNetCore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:AdminPanelNetCore.View.WindowViews"AdminPanelNetCore.View.WindowViews  5   	   7    1AdminPanelNetCore.View.WindowViews.Identification   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Blocal0clr-namespace:AdminPanelNetCore.View.WindowViews     5   	   -   5          �Name$	  Win��5       � Title$ Window1��6	   $	��190��6&   $	��600��63    � WindowStartupLocation$ CenterScreen=�6?    � AllowsTransparency$
 True��6e    � WindowStyle$
 None=�6    � 
ResizeMode$ NoResize=�6�   ��6�   Z� .��5	      �  J� Effect 5
   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         	Direction$	 265Q�6      Opacity$	 0.5Q�6/   	   ShadowDepth$	 0Q�6=   
   
BlurRadius$
 10Q�6M   .+�5   
   � $��10q�6   
������� 5        5      $	 265Q�6#   $	 0.5Q�63   $	 0Q�6A   $
 10Q�6Q   .+�5      �  � RowDefinitions 5      �� 5      $��15 �6$   62   �� 5      6&   .+�5      �� ���#0A6E9E5      �� 5      $��1��6   .+�5      �� -   5         ��Name$ 
LogTextBox��5      $��14(�62      styleLog#���   6A   
 � Tag$  Login��6d   $��24��6q   $	��340��6}   $��Right=�6�    �� Left$	 131��6�   
 �� Top$ 32��6�   G� 5      -   5         G�Name$ PassTextBox��5   "   $��14(�67   $ 	 Password��6G   $��24��6W   $	��340��6c   $��Right=�6o   $	 131��6�   $ 65��6�   �� 5      -   5         ��Name$ button_2��5       � Cursor$
 Hand��6F   $��
Выход��6T   $��25��6e   $	��155��6q   
�������$��2q�6�   ���#0A6E9E$	 139��6�   $ 99��6�   ��5      �� 5       �� 
TargetType" ��6$   .�5   "   ��  �� Property � �� �� Value �#0A6E9E6?   5       � 	Resources 5!      ��%d   '��       �� 5"      " ��6$   .�5#   "   ��  �@��CornerRadius$ 5,0,0,5��6A   5$      5%      5&      �� 5'      -   5        $ button_1��5'   :   $
 Hand��6   $��Вход��6+   $��25��6d   $	��164��6p   ���#0A6E9E
�������$��0q�6�   $	 294��6�   $ 99��6�    5(      ��%d   '��       �� 5)      " ��6$   .�5*   "   ��  �@��CornerRadius$ 0,5,5,0��6A   5+      5,      5-      5/      50      51      53      54      