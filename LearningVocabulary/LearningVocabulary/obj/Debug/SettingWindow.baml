   M S B A M L   `   `   `  ����G  CUngDungHocTu, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:LearningVocabularyLearningVocabulary  5   	   &     LearningVocabulary.SettingWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:LearningVocabulary     5   	   -   5          � Title$  Tùy chỉnh��5   	    � SizeToContent$ WidthAndHeight=�6   $	��400��6:    � WindowStartupLocation$ CenterScreen=�6b   .��5
      � -   5         �Name$ 
rootLayout��5
      $��5q�6   $	��200��6*   .+�5   
   �� .@�5      �� $��Chung��6   .��5      �  � RowDefinitions 5      �� 5      $��* �6(   �� 5      $
��auto �6(    � ColumnDefinitions 5      �� 5      .+�5      � $��5q�6    5      �� 5      $
��Auto �6/   6?   �� 5      $��* �6/   6;   �� 5      $
��Auto �6/   6>    5      �� 5      $
��Auto �6,   6<   �� 5      $
��Auto �6,   6<   �� 5      $
��Auto �6,   6<   �� 5      $
��Auto �6,   6<   �� 5       $
��Auto �6,   6<   �� 5!      $
��Auto �6,   6<   �� 5"      $
��Auto �6,   6<   .+�5$      �� $��0��6$   $��0��61   Tạo shortcut ngoài Desktop6]   �� 5%      -   5        $��chkCreateDesktopIcon��5%   A   $��0��6$   $��1��61   $��	5, 0, 0,0q�6]   6�   �� 5&      $��1��6$   $��0��61   &$Chạy khi khởi động máy tính6^   �� 5'      -   5        $��chkRunWhenStartup��5'   A   $��1��6$   $��1��61   $��	5, 0, 0,0q�6Z   6�   �� 5(      $��2��6$   $��0��61   Luôn hiển thị nghĩa:6W   �� 5)      -   5        $��chkDisplayMeaning��5)   A   $��2��6$   $��1��61   $��	5, 0, 0,0q�6Z   6�   �� 5+      $��3��6$   $��0��61   )'Số lượng từ ôn tập tối đa:6]   �� 5,      -   5        $��cmbWordLimit��5,   @   $��3��6#   $��1��60   $��	5, 0, 0,0q�6T   $
��Auto��6h   $
��Left=�6u   6�   �� 5.      $��4��6$   $��0��61   $
��Auto��6A   97Thời gian tự động đổi từ (0=không đổi):6w   �� 5/      -   5        $��cmbAutoChangeWordTime��5/   @   $��4��6#   $��1��60   $��	5, 0, 0,0q�6]   $
��Auto��6p   $
��Left=�6}   6�   �� 50      $��4��6$   $��2��61   $
��Left=�6A   $��5,0,0,0q�6\   giây6t   51      �� 52      -   5         ��Name$ butResetSetting��52      $��1��62   $��0��6?   $��Right=�6O   .��6�   Đặt về mặc định6�   53      54      �� 55      $��Giao diện��6   .��56      � $��5q�6    57      �� 58      6-    5:      �� 5;      $
��auto �6(   68   .+�5=      ��  �� Orientation$ Vertical=�6!   $��0��68   $��0��6H   .+�5>      ]� ��.  .+�5?      �� $	��Top=�6(   Ảnh nền:6G   �� 5@      -	   5         ��Name$ textBoxBackgroundImage��5@   &   $
��Left=�6F   $	��130��6\   $	��200��6k   $��0,0,10,0q�6{   	 �� 
IsReadOnly	 . 6�   �� 5A      -
   5        $ butBackgroundImage��5A   %   $��Right=�6A   .��6y   Chọn ảnh khác6�   5B      �� 5C      -   5        
 ��Name$
 previewBackgroundImage��5C       $"��Resources/Backgrounds/11.jpg��6@   $	��100��6f   $
��Left=�6v   $��0,10,0,0q�6�   6�   �� 5D      .+�5E      ]� .+�5F   "   �� $
��Left=�6,   
Opacity:6L   �� 5G   "   -   5         ��Name$% textBlockBackgroundImageOpacity��5G   ,   $��Right=�6U   100%6r   �� 5H   "   -   5         ��Name$" sliderBackgroundImageOpacity��5H   )   $��Right=�6O   $��5,0,5,0q�6f    � Value$ 1Q�6�    � Maximum$ 1Q�6�    � LargeChange$	 0.1Q�6�   6�   5J      5K      5L      5N      5O      �� 5Q      $��Trợ giúp��6   .��5R      � $��5q�6   .+�5S      �� $ Vertical=�6!   .+�5T      �� Hướng dẫn6/   �� 5U      Giới thiệu60   �� 5V      Trang chủ �� 5W      $4��.https://www.facebook.com/UngDungHocTuTiengAnh/?�6(   .�6e   StickyVocab6s   5Y      �� 5[      Kiểm tra cập nhật67   5\      5]      5^      5_      5a      5b      