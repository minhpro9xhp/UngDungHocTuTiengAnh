   M S B A M L   `   `   `  ���� G  CUngDungHocTu, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:LearningVocabularyLearningVocabulary  &     LearningVocabulary.SettingWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     2local clr-namespace:LearningVocabulary     -     � Title$  Tùy chỉnh�� � SizeToContent$ WidthAndHeight=�$	��400�� � WindowStartupLocation$ CenterScreen=�.��� -    �Name$ 
rootLayout��$��5q�$	��200��.+��� .@��� $��Chung��.���  � RowDefinitions �� $��* ��� $
��auto � � ColumnDefinitions �� .+�� $��5q� �� $
��Auto ��� $��* ��� $
��Auto � �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��$��0��Tạo shortcut ngoài Desktop�� -   $��chkCreateDesktopIcon��$��0��$��1��$��	5, 0, 0,0q��� $��1��$��0��&$Chạy khi khởi động máy tính�� -   $��chkRunWhenStartup��$��1��$��1��$��	5, 0, 0,0q��� $��2��$��0��Luôn hiển thị nghĩa:�� -   $��chkDisplayMeaning��$��2��$��1��$��	5, 0, 0,0q��� $��3��$��0��)'Số lượng từ ôn tập tối đa:�� -   $��cmbWordLimit��$��3��$��1��$��	5, 0, 0,0q�$
��Auto��$
��Left=��� $��4��$��0��$
��Auto��97Thời gian tự động đổi từ (0=không đổi):�� -   $��cmbAutoChangeWordTime��$��4��$��1��$��	5, 0, 0,0q�$
��Auto��$
��Left=��� $��4��$��2��$
��Left=�$��5,0,0,0q�giây�� -    ��Name$ butResetSetting��$��1��$��0��$��Right=�.��Đặt về mặc định�� $��Giao diện��.��� $��5q� ��  �� $
��auto �.+���  �� Orientation$ Vertical=�$��0��$��0��.+�]� ��.  .+��� $	��Top=�Ảnh nền:�� -	    ��Name$ textBoxBackgroundImage��$
��Left=�$	��130��$	��200��$��0,0,10,0q�	 �� 
IsReadOnly	 . �� -
   $ butBackgroundImage��$��Right=�.��Chọn ảnh khác�� -   
 ��Name$
 previewBackgroundImage��$"��Resources/Backgrounds/11.jpg��$	��100��$
��Left=�$��0,10,0,0q��� .+�]� .+��� $
��Left=�
Opacity:�� -    ��Name$% textBlockBackgroundImageOpacity��$��Right=�100%�� -    ��Name$" sliderBackgroundImageOpacity��$��Right=�$��5,0,5,0q� � Value$ 1Q� � Maximum$ 1Q� � LargeChange$	 0.1Q��� $��Trợ giúp��.��� $��5q�.+��� $ Vertical=�.+��� Hướng dẫn�� Giới thiệu�� Trang chủ �� $4��.https://www.facebook.com/UngDungHocTuTiengAnh/?�.�StickyVocab�� Kiểm tra cập nhật