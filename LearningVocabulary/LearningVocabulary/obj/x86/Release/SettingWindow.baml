   M S B A M L   `   `   `  ���� M  ILearningVocabulary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:LearningVocabularyLearningVocabulary  &     LearningVocabulary.SettingWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     2local clr-namespace:LearningVocabulary     -     � Title$  Tùy chỉnh�� � SizeToContent$ WidthAndHeight=�$	��400�� � WindowStartupLocation$ CenterScreen=�.��� $��10q� � ColumnDefinitions �� $
��Auto ��� $��* ��� $
��Auto � � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��$��0��&$Chạy khi khởi động máy tính�� -   $��chkRunWhenStartup��$��0��$��1��$��	5, 0, 0,0q��� $��1��$��0��Luôn hiển thị nghĩa:�� -   $��chkDisplayMeaning��$��1��$��1��$��	5, 0, 0,0q��� $��2��$��0��)'Số lượng từ ôn tập tối đa:�� -   $��cmbWordLimit��$��2��$��1��$��	5, 0, 0,0q�$
��Auto��$
��Left=��� $��3��$��0��$
��Auto��97Thời gian tự động đổi từ (0=không đổi):�� -   $��cmbAutoChangeWordTime��$��3��$��1��$��	5, 0, 0,0q�$
��Auto��$
��Left=��� $��3��$��2��$
��Left=�$��5,0,0,0q�giây]� $��4��$��0��$��2����.  .+��� $	��Top=�Ảnh nền:�� -    ��Name$ previewBackgroundImage��$��Bottom=�$	��100��$
��Left=�$��0,10,0,0q��� -    ��Name$ textBoxBackgroundImage��$
��Left=�$	��130��$	��200��$��0,0,10,0q� �� 
IsReadOnly . �� -    ��Name$ butBackgroundImage��$��Right=�.��Chọn ảnh khác�� -	   $ butResetSetting��$��5��$��0��$��3��$��Right=�$��0,5,0,0q�.��Đặt về mặc định