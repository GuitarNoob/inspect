   M S B A M L   `   `   `  ����L  HProcessInspection, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:ProcessInspection.UserControlsProcessInspection.UserControls  5   	   "    ProcessInspection.MainWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   U QMahApps.Metro, Version=0.14.0.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f;controls,http://metro.mahapps.com/winfx/xaml/controls  5   	   7this,clr-namespace:ProcessInspection.UserControls  5   	     � Title$  ISI Inspection��5   	   $��472.046��6    $��744.885��61   ���	#FFE8E8E8.��5      � -   5        $��MainGrid��5       � RowDefinitions 5   
   �� 5	      $��35 �6   �� 5
      $	��44* �6   .+�5   
   �� $��0��6   ���	#FF4949496!   �� 5   
   $��0��6   $��Current User:��6   $��Right=�66   $��	0,5,145,0q�6R   $	��Top=�6e   
�������6}   �� 5   
   $��0��6   $��Right=�6F   $��0,5,10,0q�6b   $	��Top=�6t   $	��130��6�   
���������6   ��  �� Path$ CurrentUserName�6�   � 5   
   -   5        $��GridContent��5      $��1��6"   $��0,10,0,0q�6/   5      d� 5   
   -   5        $
��Home��5   �    d� 	IsChecked$
 TrueY�6   $
��Left=�6(   
�������$��Bottom=�6V   $��35��6q       MetroCircleToggleButtonStyle#���   6|   $��35��6�   $��10,0,0,0q�6�   $��FontAwesome)�6�   $	����6�   6	  d� 5   
   -   5        $��	Dashboard��5   �   $
��Left=�6   
�������$��Bottom=�6E   $��35��6`   #���   6k   $��35��6�   $��45,0,0,0q�6�   $��FontAwesome)�6�   $	����6�   6�   d� 5   
   -   5        $��Settings��5   �   $
��Left=�6   
�������$��Bottom=�6E   $��35��6`   #���   6k   $��35��6�   $��80,0,0,0q�6�   $��FontAwesome)�6�   $	����6�   6�   5      5      