   M S B A M L   `   `   `  ����I  EWPFAppMagazine, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WPFAppMagazineWPFAppMagazine  5   	       WPFAppMagazine.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:WPFAppMagazine     5   	     � Title$   ��5   	   $	��450��6   $	��800��6   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��75* �6   �� 5      $	��25* �6    � RowDefinitions 5   
   �� 5      $	��90* �6   �� 5      $	��10* �6   .+�5   
   �� -   5        $��textBoxBarCode��5      $
��Left=�6(   $��
242,31,0,0q�6C    �� TextWrapping$
 Wrap=�6W   $	��Top=�6l   $	��188��6�   $��33��6�   $��24(�6�    �� 	MaxLength$ 13��6�   6�   �� 5   
   $
��Left=�6   $��	27,32,0,0q�6/   $
��Wrap=�6B   $��Enter barcode here��6V   $	��Top=�6p   $��24(�6�   �� 5   
   -   5        $��listBoxStorage��5      $��1��6(   $
��Auto=�68   ��5      �� 5      .R�5      �� $��12(�61   ��6    �� 61   5      5      �� 5   
   -   5         ��Name$ buttonAddByBarcode��5      $��Add product��6-   $
��Left=�6C   $��
454,38,0,0q�6^   $	��Top=�6r   $	��110��6�   $��16(�6�   ���	#FFB3E2C9${�False��6�   6�   �� 5   
   -   5         ��Name$ textBlockHasProduct��5      $
��Left=�61   $��
443,68,0,0q�6L   $
��Wrap=�6`   $#��no products with this barcode��6t   $	��Top=�6�   $��10(�6�   �� 5   
   $
��Left=�6   $��
27,104,0,0q�6/   $
��Wrap=�6C   $��Result sum:��6W   $	��Top=�6j   $��20(�6�   �� 5   
   -   5        $ textBlockSum��5      $
��Left=�6*   $��132,107,0,0q�6E   $
��Wrap=�6Z   $��0��6n   $	��Top=�6w   $��18(�6�   $��Italic$�6�   �� 5   
   -   5        $ buttonCalculateDiscount��5      $��Calculate discount��62   $
��Left=�6O   $��454,110,0,0q�6j   $	��Top=�6   $	��110��6�   $��13(�6�   6�   �� 5    
   -   5        $ buttonPrintReceipt��5       $��Print the receipt��6-   $��Center=�6I   $��0,10,0,0q�6f   $	��Top=�6x   $��1��6�   $��1��6�   $	��132��6�   $��16(�6�   6�   &   System.Windows.Controls.DataGrid  5!   
   -   5          Name$ dataGridProductsToBuy��5!      $��10,136,0,43q�6]      AutoGenerateColumns$ False��6r   	   
IsReadOnly$
	 True��6�   $��2��6�   
   Columns
 5"      0  *System.Windows.Controls.DataGridTextColumn  5#      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+  5$      $
 Name��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6L    63   �� *Name+6L     5%      $ Brand��6%   $
 Auto 6N    64   �� *Brand+6N     5&      $ Count��6%   $
 Auto 6N    64   �� *Count+6N     5'      $ Discount��6%    67   �� *
Discount+  5(      $ Price��6%   $
 Auto 6N    64   �� *Price+6N   4  .System.Windows.Controls.DataGridTemplateColumn  5)      $ Cancel��6)   $ 50 69      CellTemplate 5*      �� 5+      .R�5,      �� -	   5        $��Cancel��5,   %   66   5-      5/        50      $	 Add��6)   $ 40 66    51      �� 52      .R�53      �� -
   5        $��+��53   %   61   54      56      58      59      5:      