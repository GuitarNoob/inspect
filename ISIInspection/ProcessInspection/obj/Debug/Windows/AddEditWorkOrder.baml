   M S B A M L   `   `   `  ����  ProcessInspection0    *ProcessInspection.Windows.AddEditWorkOrder   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Add Edit Work Order��5   	   $	��290��6%   $	��460��62   .��5      � -   5        $��MainGrid��5      .+�5   
   �� -   5         ��Name$ 
ButtonSave��5       �� 	IsDefault . $
��Save��66   $��Right=�6E   $��	0,0,90,10q�6a   $��Bottom=�6t   $��75��6�   6�   �� 5   
   -   5        $ ButtonCancel��5       �� IsCancel . $��Cancel��67   $��Right=�6H   $��	0,0,10,10q�6d   $��Bottom=�6w   $��75��6�   6�   �� 5   
   $��Order Number��6   $
��Left=�6'   $��	10,10,0,0q�6B   $	��Top=�6U   �� 5	   
   -   5         ��Name$ TextBoxName��5	      $��23��6'   $��103,13,10,0q�63    �� TextWrapping$
 Wrap=�6H   $	��Top=�6�   ��6\   ��  �� Path$ WorkOrder.OrderNumber� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5
   
   -   5        	 ��Name$	 TextBoxCustomer��5
      $��23��6,   $��103,41,10,0q�68   $	��Top=�6�   
 �� SelectedItem
 6M   �� $ WorkOrder.Customer�$ TwoWay=�$ PropertyChanged=�6�   �� 5   
   $��Customer��6   $
��Left=�6#   $��	10,38,0,0q�6>   $	��Top=�6Q   5      5      