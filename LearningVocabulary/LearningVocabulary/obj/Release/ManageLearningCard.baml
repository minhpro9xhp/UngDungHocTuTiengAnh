   M S B A M L   `   `   `  ���� G  CUngDungHocTu, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:UngDungHocTuUngDungHocTu  %    UngDungHocTu.ManageLearningCard   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:UngDungHocTu       � Title$,  &Quản lý danh sách từ đang học��$
��Auto�� � SizeToContent$ WidthAndHeight=�$	��600��$
��Auto��$	��800�� � 
ResizeMode$ NoResize=�.��� $��5q� � ColumnDefinitions ��  � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��5q�$��0��$��0�� �� Orientation$ Vertical=�.+��� $��Center=�$��Arial)�$��15(�DANH SÁCH TỪ ĐANG HỌC�� $
��Left=�$��12(�$��10,0,0,0q�	Ghi chú:�� $
��Left=�$��12(�$��10,0,0,0q�$
��Wrap=���1. Từ "đang học" là những từ sẽ được phần mềm hiển thị để ôn tập. Số lượng từ đang học được cài đặt trong Tùy chọn�� $
��Left=�$��12(�$��10,0,0,0q�`^2. Để thay đổi nội dung từ, chỉnh sửa trực tiếp giá trị trong bảng CSDL�� $
��Left=�$��12(�$��10,0,0,0q�\Z3. Để ngừng học từ, chọn từ / nhóm từ và nhấn nút "Ngừng học từ"�� $
��Left=�$��12(�$��10,0,0,0q�$��WrapWithOverflow=�^\4. Để thêm từ mới, bạn phải ngừng học một số từ cũ để giành chỗ&   System.Windows.Controls.DataGrid  -   $��	gridDecks��$	��200��$	��300��$��1��$��0��$��12(�$��Center=���.    CanUserAddRows .     CanUserDeleteRows .  ]� $��2��$��0��$��5q���.  .+��� -   $��butCreateRandomList��$
��Left=�$��5q�$
��Auto��$��10(�$��5q�.��-+Khởi tạo sách từ học ngẫu nhiên�� -   $��butAddCardFromDatabase��$
��Left=�$��5q�$
��Auto��$��10(�$��5q�.�� Bổ sung từ học từ CSDL�� -   $��butFillListWithRandomCard��$
��Left=�$��5q�$
��Auto��$��10(�$��5q�.��$"Bổ sung từ học ngẫu nhiên�� -   $��butReturnDatabase��$
��Left=�$��5q�$
��Auto��$��10(�$��5q�.��-+Ngừng học từ này. Chuyển về CSDL