   M S B A M L   `   `   `  ����  ProcessInspection6    0ProcessInspection.Windows.AddEditPartInformation   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Add Edit Customer��5   	   $	��456��6#   $	��500��60   .��5      � -   5        $��MainGrid��5      .+�5   
   �� $��0,0,0,40q�6   .@�5      �� $��Information��6   .��5      � -   5        $��InfoGrid��5      .+�5	      �� $��Part Number��6   $
��Left=�62   $��	10,10,0,0q�6M   $	��Top=�6`   �� 5
      -   5         ��Name$ TextBoxName��5
      $��23��63   $��
93,13,10,0q�6?    �� TextWrapping$
 Wrap=�6S   $	��Top=�6�   ��6g   ��  �� Path$ Part.PartNumber� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5      -   5        $ TextBoxDesc��5      $��23��63   $��
93,41,10,0q�6?   $
 Wrap=�6S   $	��Top=�6�   ��6g   �� $ Part.Revision�$ TwoWay=�$ PropertyChanged=�6�   �� 5      $��Revision��6   $
��Left=�6/   $��	10,38,0,0q�6J   $	��Top=�6]   �� 5      -   5        $ TextBoxDesc_Copy��5      $��23��68   $��
93,69,10,0q�6D   $
 Wrap=�6X   $	��Top=�6�   ��6l   �� $ 	Part.Item�$ TwoWay=�$ PropertyChanged=�6�   �� 5      $
��Item��6   $
��Left=�6+   $��	10,66,0,0q�6F   $	��Top=�6Y   5      5      �� 5      -   5        $��MeasurementTab��5   ,   $��Measurements��6   5      5      �� 5   
   -   5         ��Name$ 
ButtonSave��5       �� 	IsDefault . $
��Save��66   $��Right=�6E   $��	0,0,90,10q�6a   $��Bottom=�6t   $��75��6�   6�   �� 5   
   -   5        $ ButtonCancel��5       �� IsCancel . $��Cancel��67   $��Right=�6H   $��	0,0,10,10q�6d   $��Bottom=�6w   $��75��6�   6�   5      5      