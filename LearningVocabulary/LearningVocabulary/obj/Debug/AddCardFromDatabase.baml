   M S B A M L   `   `   `  ����G  CUngDungHocTu, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:UngDungHocTuUngDungHocTu  5   	   &     UngDungHocTu.AddCardFromDatabase   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:UngDungHocTu     5   	     � Title$  Chọn từ để học��5   	   $
��Auto��6     � SizeToContent$ WidthAndHeight=�6.   $	��600��6M   $
��Auto��6]   $	��800��6j   .��5	      � $��5q�6    � ColumnDefinitions 5
   
   �� 5      6!    � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   .+�5   
   �� $��5q�6   $��0��6    $��0��6-    �� Orientation$ Vertical=�6=   .+�5      �� $��Center=�6   $��Arial)�65   $��15(�6H   CHỌN TỪ ĐỂ HỌC6f   �� 5      $
��Left=�6   $��12(�63   $��10,0,0,0q�6A   	Ghi chú:5      �� 5      $
��Left=�6   $��12(�63   $��10,0,0,0q�6A   $
��Wrap=�6S   OM1. Chọn một hoặc nhiều từ trong danh sách và nhấn "Chọn từ"5      �� 5      $
��Left=�6   $��12(�63   $��10,0,0,0q�6A   ��2. Danh sách từ đang học sẽ được điền đầy bởi từ bạn chọn, cho tới khi đạt tới số lượng giới hạn5      5"      &   System.Windows.Controls.DataGrid  5#   
   -   5        $��	gridDecks��5#      $	��200��6$   $	��300��63   $��1��6C   $��0��6P   $��12(�6`   $��Center=�6n   ��.    CanUserAddRows .  5$      ]� 5%   
   $��2��6   $��0��6!   $��5q�61   ��.  .+�5&      �� -   5        $��	butChoose��5&      $
��Left=�6&   $��5q�6=   $
��Auto��6H   $��10(�6U   $��5q�6c   .��6�   Chọn những từ trên6�   5'      5(      5)      