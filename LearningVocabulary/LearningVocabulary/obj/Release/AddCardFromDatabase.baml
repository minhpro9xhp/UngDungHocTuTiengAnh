   M S B A M L   `   `   `  ���� G  CUngDungHocTu, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:UngDungHocTuUngDungHocTu  &     UngDungHocTu.AddCardFromDatabase   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:UngDungHocTu       � Title$  Chọn từ để học��$
��Auto�� � SizeToContent$ WidthAndHeight=�$	��600��$
��Auto��$	��800��.��� $��5q� � ColumnDefinitions ��  � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��5q�$��0��$��0�� �� Orientation$ Vertical=�.+��� $��Center=�$��Arial)�$��15(�CHỌN TỪ ĐỂ HỌC�� $
��Left=�$��12(�$��10,0,0,0q�	Ghi chú:�� $
��Left=�$��12(�$��10,0,0,0q�$
��Wrap=�OM1. Chọn một hoặc nhiều từ trong danh sách và nhấn "Chọn từ"�� $
��Left=�$��12(�$��10,0,0,0q���2. Danh sách từ đang học sẽ được điền đầy bởi từ bạn chọn, cho tới khi đạt tới số lượng giới hạn&   System.Windows.Controls.DataGrid  -   $��	gridDecks��$	��200��$	��300��$��1��$��0��$��12(�$��Center=���.    CanUserAddRows .  ]� $��2��$��0��$��5q���.  .+��� -   $��	butChoose��$
��Left=�$��5q�$
��Auto��$��10(�$��5q�.��Chọn những từ trên