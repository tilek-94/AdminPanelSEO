   M S B A M L   `   `   `  ����L  HAdminPanelNetCore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:AdminPanelNetCore.View.WindowViews"AdminPanelNetCore.View.WindowViews  5   	   2    ,AdminPanelNetCore.View.WindowViews.MessageOk   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Blocal0clr-namespace:AdminPanelNetCore.View.WindowViews     5   	     � Title$  MessageO��5      $	��150��6   $	��400��6&    � WindowStartupLocation$ CenterScreen=�62    � AllowsTransparency$
 True��5	   	    � WindowStyle$
 None=�5
   	   ��6   Z� .��5      � $��10q�6   
������� � RowDefinitions 5   
   �� 5      $��35 �6   �� 5      $
��178* �6    J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 10Q�6      	Direction$	 270Q�6/      Opacity$	 0.5Q�6?   	   ShadowDepth$	 0Q�6M   .+�5   
   � $��0��6   .+�5      �� ���#0A6E9E$��10��6+   $	��Top=�67   5      �� 5   
   $��1��6   .+�5      �� -   5        
 ��Name$
 message��5      $��18(�6)    �� TextAlignment$ Center=�67   ���#0A6E9E$
��Wrap=�5   -   $��Center=�5      $��Center=�5      $��	12,0,10,0q�63   $	��358��6F   $��You message!��5      6.   �� 5       �� Orientation$ 
Horizontal=�6   $��Center=�62   .+�5       �� -   5         ��Name$ button��5"         ButtonStyle#���   5       $��0,10,0,0q�6@   $��Ok��5!      $	��168��5"   '   $��26��63   5$      5%      5&      5'      