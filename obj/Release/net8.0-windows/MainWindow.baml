   M S B A M L   `   `   `  ���� I  EWPFAppMagazine, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WPFAppMagazineWPFAppMagazine      WPFAppMagazine.MainWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:WPFAppMagazine       � Title$   ��$	��450��$	��800��.���  � ColumnDefinitions �� $	��75* ��� $	��25* � � RowDefinitions �� $	��90* ��� $	��10* �.+��� -   $��textBoxBarCode��$
��Left=�$��
242,31,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��188��$��33��$��24(� �� 	MaxLength$ 13���� $
��Left=�$��	27,32,0,0q�$
��Wrap=�$��Enter barcode here��$	��Top=�$��24(��� -   $��listBoxStorage��$��1��$
��Auto=����� .R��� $��12(����� �� -    ��Name$ buttonAddByBarcode��$��Add product��$
��Left=�$��
454,38,0,0q�$	��Top=�$	��110��$��16(����	#FFB3E2C9${�False���� -    ��Name$ textBlockHasProduct��$
��Left=�$��
443,68,0,0q�$
��Wrap=�$#��no products with this barcode��$	��Top=�$��10(��� $
��Left=�$��
27,104,0,0q�$
��Wrap=�$��Result sum:��$	��Top=�$��20(��� -   $ textBlockSum��$
��Left=�$��132,107,0,0q�$
��Wrap=�$��0��$	��Top=�$��18(�$��Italic$��� -   $ buttonCalculateDiscount��$��Calculate discount��$
��Left=�$��454,110,0,0q�$	��Top=�$	��110��$��13(��� -   $ buttonPrintReceipt��$��Print the receipt��$��Center=�$��0,10,0,0q�$	��Top=�$��1��$��1��$	��132��$��16(�&   System.Windows.Controls.DataGrid  -     Name$ dataGridProductsToBuy��$��10,136,0,43q�   AutoGenerateColumns$ False��	   
IsReadOnly$
	 True��$��2��
   Columns
 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ ID��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Id+  $
 Name��   Width5  /System.Windows.Controls.DataGridLengthConverter$ *  �� *Name+  $ Brand��$
 Auto  �� *Brand+  $ Count��$
 Auto  �� *Count+  $ Discount�� �� *
Discount+  $ Price��$
 Auto  �� *Price+4  .System.Windows.Controls.DataGridTemplateColumn  $ Cancel��$ 50    CellTemplate �� .R��� -	   $��Cancel��  $	 Add��$ 40  �� .R��� -
   $��+��