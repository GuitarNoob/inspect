   M S B A M L   `   `   `  ����  ProcessInspection=    7ProcessInspection.UserControls.MeasurementSPUserControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5        .��5      � -   5        $��MainGrid��5      $��0,3,0,-3q�6   .+�5	   
   &   System.Windows.Controls.DataGrid  -   5           Name$  contentDataGrid��5	         AutoGenerateColumns .    EnableRowVirtualization . $��10,38,10,10q�5
   )      RowDetailsVisibilityMode$ 	Collapsed=�5         
IsReadOnly . ��5
      ��  � ContextMenu 5      �� 5      .@�5      m� -   5        $��MenuAdd��5   ,   $	��Add��6   6;   m� 5      -   5        $��MenuEdit��5   -   $
��Edit��6   6=   m� 5      -   5        $��
MenuRemove��5   /   $��Remove��6   6A   5      5      �� 5   
   -   5         ��Name$ ButtonRefresh��5       �� 	IsDefault . $��Refresh��69   $��Right=�6K   $��	0,10,10,0q�6g   $	��Top=�6z   $��98��6�   6�   �� 5   
   -   5         ��Name$ TextboxSearch��5      $��23��6)   $��75,10,113,0q�65   	 �� TextWrapping$
	 Wrap=�6J   $	��Top=�6^   �� 5   
   $��Search��6   $
��Left=�6!   $��10,7,0,0q�6<   $	��Top=�6N   5      5      