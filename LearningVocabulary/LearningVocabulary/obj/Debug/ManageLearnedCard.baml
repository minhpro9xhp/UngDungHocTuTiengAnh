   M S B A M L   `   `   `  ����G  CUngDungHocTu, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:UngDungHocTuUngDungHocTu  5   	   $    UngDungHocTu.ManageLearnedCard   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:UngDungHocTu     5   	     � Title$+  %Quản lý danh sách từ đã nhớ��5   	   $
��Auto��6-    � SizeToContent$ WidthAndHeight=�6;   $	��600��6Z   $
��Auto��6j   $	��800��6w    � 
ResizeMode$ NoResize=�6�   .��5	      � $��5q�6    � ColumnDefinitions 5
   
   �� 5      6!    � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   .+�5   
   �� $��5q�6   $��0��6    $��0��6-    �� Orientation$ Vertical=�6=   .+�5      �� $��Center=�6   $��Arial)�65   $��15(�6H   DANH SÁCH TỪ ĐÃ NHỚ6k   �� 5      $
��Left=�6   $��12(�63   $��10,0,0,0q�6A   	Ghi chú:5      �� 5      $
��Left=�6   $��12(�63   $��10,0,0,0q�6A   $
��Wrap=�6S   ��1. Từ "đã nhớ" là những từ được nhận phản hồi "Đã ghi nhớ" khi ôn tập và được loại ra khỏi danh sách từ cần học5      �� 5      $
��Left=�6   $��12(�63   $��10,0,0,0q�6A   `^2. Để thay đổi nội dung từ, chỉnh sửa trực tiếp giá trị trong bảng CSDL5      �� 5       $
��Left=�6   $��12(�63   $��10,0,0,0q�6A   MK3. Để xóa từ, chọn hàng tương ứng trong CSDL và nhấn Delete5"      �� 5#      $
��Left=�6   $��12(�63   $��10,0,0,0q�6A   $��WrapWithOverflow=�6S   ~|4. Để đưa từ đã ghi nhớ trở lại CSDL học từ, chọn từ trong danh sách và nhấn "Chuyển về CSDL"5%      5'      &   System.Windows.Controls.DataGrid  5(   
   -   5        $��	gridDecks��5(      $	��200��6$   $	��300��63   $��1��6C   $��0��6P   $��12(�6`   $��Center=�6n   ��.    CanUserAddRows .  5)      ]� 5*   
   $��2��6   $��0��6!   $��5q�61   ��.  .+�5+      �� -   5        $��butMoveBackToDatabase��5+      $
��Left=�62   $��5q�6I   $
��Auto��6T   $��10(�6a   $��5q�6o   .��6�   Chuyển về CSDL từ6�   5,      5-      5.      