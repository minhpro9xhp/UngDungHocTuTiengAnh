   M S B A M L   `   `   `  ����G  CUngDungHocTu, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:UngDungHocTuUngDungHocTu  5   	   %    UngDungHocTu.ManageLearningCard   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:UngDungHocTu     5   	     � Title$,  &Quản lý danh sách từ đang học��5   	   $
��Auto��6/    � SizeToContent$ WidthAndHeight=�6=   $	��600��6\   $
��Auto��6l   $	��800��6y    � 
ResizeMode$ NoResize=�6�   .��5	      � $��5q�6    � ColumnDefinitions 5
   
   �� 5      6!    � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   .+�5   
   �� $��5q�6   $��0��6    $��0��6-    �� Orientation$ Vertical=�6=   .+�5      �� $��Center=�6   $��Arial)�65   $��15(�6H   DANH SÁCH TỪ ĐANG HỌC6m   �� 5      $
��Left=�6   $��12(�63   $��10,0,0,0q�6A   	Ghi chú:5      �� 5      $
��Left=�6   $��12(�63   $��10,0,0,0q�6A   $
��Wrap=�6S   ��1. Từ "đang học" là những từ sẽ được phần mềm hiển thị để ôn tập. Số lượng từ đang học được cài đặt trong Tùy chọn5      �� 5      $
��Left=�6   $��12(�63   $��10,0,0,0q�6A   `^2. Để thay đổi nội dung từ, chỉnh sửa trực tiếp giá trị trong bảng CSDL5      �� 5       $
��Left=�6   $��12(�63   $��10,0,0,0q�6A   \Z3. Để ngừng học từ, chọn từ / nhóm từ và nhấn nút "Ngừng học từ"5"      �� 5#      $
��Left=�6   $��12(�63   $��10,0,0,0q�6A   $��WrapWithOverflow=�6S   ^\4. Để thêm từ mới, bạn phải ngừng học một số từ cũ để giành chỗ5%      5'      &   System.Windows.Controls.DataGrid  5(   
   -   5        $��	gridDecks��5(      $	��200��6$   $	��300��63   $��1��6C   $��0��6P   $��12(�6`   $��Center=�6n   ��.    CanUserAddRows .     CanUserDeleteRows .  5)      ]� 5*   
   $��2��6   $��0��6!   $��5q�61   ��.  .+�5+      �� -   5        $��butCreateRandomList��5+      $
��Left=�60   $��5q�6G   $
��Auto��6R   $��10(�6_   $��5q�6m   .��6�   -+Khởi tạo sách từ học ngẫu nhiên6�   �� 5,      -   5        $��butAddCardFromDatabase��5,      $
��Left=�63   $��5q�6J   $
��Auto��6U   $��10(�6b   $��5q�6p   .��6�    Bổ sung từ học từ CSDL6�   �� 5-      -   5        $��butFillListWithRandomCard��5-      $
��Left=�66   $��5q�6M   $
��Auto��6X   $��10(�6e   $��5q�6s   .��6�   $"Bổ sung từ học ngẫu nhiên6�   �� 5.      -   5        $��butReturnDatabase��5.      $
��Left=�6.   $��5q�6E   $
��Auto��6P   $��10(�6]   $��5q�6k   .��6�   -+Ngừng học từ này. Chuyển về CSDL6�   5/      50      51      