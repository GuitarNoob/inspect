   M S B A M L   `   `   `  ����  ProcessInspection3    -ProcessInspection.Windows.AddEditPartSetPoint   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Add Edit Customer��5   	   $	��256��6#   $	��426��60   .��5      � -   5        $��MainGrid��5      .+�5   
   �� -   5         ��Name$ 
ButtonSave��5       �� 	IsDefault . $
��Save��66   $��Right=�6E   $��	0,0,90,10q�6a   $��Bottom=�6t   $��75��6�   6�   �� 5   
   -   5        $ ButtonCancel��5       �� IsCancel . $��Cancel��67   $��Right=�6H   $��	0,0,10,10q�6d   $��Bottom=�6w   $��75��6�   6�   �� 5   
   $��Char Number��6   $
��Left=�6&   $��	10,10,0,0q�6A   $	��Top=�6T   �� 5	   
   -   5         ��Name$ TextBoxName��5	      $��23��6'   $��
96,13,10,0q�63    �� TextWrapping$
 Wrap=�6G   $	��Top=�6�   ��6[   ��  �� Path$ PartMeasurementSP.Number� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5
   
   -   5        $ TextBoxDesc��5
      $��23��6'   $��
96,41,10,0q�63   $
 Wrap=�6G   $	��Top=�6�   ��6[   �� $  PartMeasurementSP.SetPoint�	 �� StringFormat$	 F4��$ PropertyChanged=�
 �� ValidatesOnDataErrors
 . 6�   �� 5   
   $��	Set Point��6   $
��Left=�6$   $��	10,38,0,0q�6?   $	��Top=�6R   �� 5   
   -   5        $ TextBoxDesc_Copy��5      $��23��6,   $��
96,69,10,0q�68   $
 Wrap=�6L   $	��Top=�6�   ��6`   �� *PartMeasurementSP.Tolerance+$	 F4��$ PropertyChanged=�
 . 6�   �� 5   
   $��	Tolerance��6   $
��Left=�6$   $��	10,69,0,0q�6?   $	��Top=�6R   �� 5   
   -   5        $ TextBoxDesc_Copy1��5      $��23��6-   $��
96,98,10,0q�69   $
 Wrap=�6M   $	��Top=�6�   ��6a   �� *PartMeasurementSP.Units+$ TwoWay=�$ PropertyChanged=�6�   �� 5   
   $��Units��6   $
��Left=�6    $��	10,98,0,0q�6;   $	��Top=�6N   5      5      