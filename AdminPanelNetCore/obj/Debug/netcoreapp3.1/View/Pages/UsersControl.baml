   M S B A M L   `   `   `  ����L  HAdminPanelNetCore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:AdminPanelNetCore.View.PagesAdminPanelNetCore.View.Pages  5      /    )AdminPanelNetCore.View.Pages.UsersControl   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:AdminPanelNetCore.View.Pages     5      .��5	      � $��20q�6     � RowDefinitions  5   
   �� 5      $	��240 �6   �� 5      $��* �6   .+�5   
   � $��0��6   .+�5      �� .+�5      �� $(��"../../Images/Just_Image/Person.JPG��6   $	��120��6D   $	��140��6P    �� Left$ 17��6]   
 �� Top$ 26��6n   �� 5      -   5         ��Name$ UserNameTextBox1��5      $��Ф.И.О��67   $	 177��6D   $ 20��6V   �� 5      $��14(�6:      textbox_style#���   6I   
 � Tag$ 	 Ф.И.О��6q   $��24��6~   $	��254��6�   $	 269��6�   $ 16��6�   ��6   �� *Users.UserName+6�   �� 5      -   5        $ Otdel��5      $��
Отдел��6+   $	 177��68   $ 51��6J   $��Center=�6Z   $	��Top=�6w   �� 5       �� DisplayMemberPath$ NamePosition��5      $	 269��5      $ 47��6-   $��Center=�6=   $	��Top=�6Z   ��5      �� *PositionList+ �� SelectedItem 5      �� *SelectedPosition+5   Z   �� 5      -   5        $	 log��5      $��
Логин��6)   $	 178��66   $ 80��6H   $��Center=�6X   $	��Top=�6u   �� 5      -   5         ��Name$ LoginTextBox��5   7   $��14(�6M   #���   6\   $ 
Логин��6�   $��24��6�   $	��254��6�   $	 269��6�   $ 76��6�   $��Center=�6�   $	��Top=�6�   ��6   �� *Users.Login+6�   �� 5      -   5        $
 pass��5      $��Пароль��6*   $	 177��68   $	 106��6J   $��Center=�6[   $	��Top=�6x   �� 5      -   5        $ PasswordTextBox��5   :   $��14(�6S   #���   6b   $ Пароль��6�   $��24��6�   $	��254��6�   $	 269��6�   $	 105��6�   $��Center=�6�   $	��Top=�6�   ��6   �� *Users.Password+6�   �� 5      -   5         ��Name$ 
SaveButton��5        ButtonStyle#���  6P   $��Сохранить��6�   $	 255��6�   $	 148��6�   ��6-   �� *AddDataCommand+5      �� 5      #���  69   $y�Visible=�6k   $��Изменить��6�   $	 419��6�   $	 148��6�   $
��Left=�6�   $��Center=�6�   ��6   �� *EditCommand+6�   5       5!      � 5"   
   $��1��6   .+�5#      &   System.Windows.Controls.DataGrid  	   
IsReadOnly$
	 True��6   $��
10,-40,0,0q�5$      $��12(�6+   
   CanUserAddRows$
 False��5'        grid_xml#���  6.     
hederstyle   ColumnHeaderStyle# �  5(      $��Stretch=�5)      "   VerticalScrollBarVisibility$
 Auto=�5*         HeadersVisibility$ Column=�5+         AutoGenerateColumns$ False��5,      ��5%      �� *
UserList+ 5&      �� *SelectedUser+   Columns 5-      0  *System.Windows.Controls.DataGridTextColumn  5.      ,  &System.Windows.Controls.DataGridColumn   Header$	 №��6*      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 65   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6@   �� *Id+  5/      -   5        fio��$ Ф.И.О��5/   7    6F   �� *
UserName+  50      -	   5        otd��$ 
Отдел��50   7    6F   �� *Position.NamePosition+  51      -
   5        log1��$ 
Логин��51   8    6G   �� *Login+  52      -   5        	pass1��$ Пароль��52   9    6I   �� *
Password+4  .System.Windows.Controls.DataGridTemplateColumn  53      -   5        izmenit��$ Изменить��53   ?   $ 80 6Q      CellTemplate 54      �� 55      .R�56   "   ��   Close_Button#���  6)   $��0,0,0,0q�6P    � Cursor$
 Hand��6j   .��57   &   �� $ ��../../Images/Icon/Edit.png��6,   $��20��6P   58   #   59      5;        5<      -   5        
udalit��$ Удалить��5<   >   $ 80 6O    5=      �� 5>      .R�5?   "   �� #���  5A   %   $��0,0,0,0q�6L   $
 Hand��6f   ��5?   )   ��  �� Path$ DataContext.DeleteCommand� �� RelativeSource �� *FindAncestor+ �� AncestorType"  .��5B   &   �� $#��../../Images/Icon/udalit4.png��6,   $��20��6S   5C   #   5D      5F      5H      5I      5J      5K      