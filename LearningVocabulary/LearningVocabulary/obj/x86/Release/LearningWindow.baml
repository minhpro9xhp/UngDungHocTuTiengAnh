   M S B A M L   `   `   `  ���� M  ILearningVocabulary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:LearningVocabularyLearningVocabulary  '    !LearningVocabulary.LearningWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     2local clr-namespace:LearningVocabulary     -     � Title$  Ung Dung Hoc Tu��$
��Auto��$	��200��$	��300�� � Topmost .  � SizeToContent$ WidthAndHeight=� � 
ResizeMode$ NoResize=� � ShowInTaskbar .   � WindowStyle$
 None=� � AllowsTransparency . ���� -   backgroundImage��.���� -   $��	stackCard��$��5,5,5,5q� �� Orientation$ Vertical=�.+�]� ��.  .+��� -   $��chkDisplayMeaning��$y�	Collapsed=�$
��Left=� � ToolTip$ Always display meaning ?��$��10(��� $y�	Collapsed=�$
��Left=�$��5,0,0,0q�$��9(�$��Center=�Luôn hiển thị nghĩa�� -   $��butExit��$��Right=�$��9(�$ Thoát��.���� $��Resources/exit.png��$��12���� -   $��butMinimize��$��Right=�$��0,0,5,0q�$��9(�$ 	Thu nhỏ��.���� $��Resources/minimize.png��$��12���� -   $��butAbout��$��Right=�$��0,0,5,0q�$��9(�$ Giới thiệu��.���� $��Resources/about.png��$��12���� -   $��butMainMenu��$
��Left=�$��0,0,5,0q�$��9(�$ Quản lý CSDL từ��.���� $��Resources/manage.jpg��$��12���� -	   $��
butSetting��$
��Left=�$��0,0,5,0q�$��9(�$ Cài đặt��.���� $��Resources/setting.png��$��12���� $ Vertical=�$��0��$��0��.+��� $ 
Horizontal=�$��Center=�$��Center=�.+��� -
   $��txtWord��$��30(�$
��Wrap=��� -   $��imgSpeak��$��Resources/speak.png��$��15��$��5,0,0,0q�$ Phát âm từ này���� -   $��txtPronunication��$��Center=�$��Center=�$��12(�$
��Wrap=��� -   $��txtFirstMeaning��$��Center=�$��Center=�$��0,5,0,0q�$��12(�$
��Wrap=�	 �� TextAlignment$	 Justify=��� -   $��txtSecondMeaning��$��Center=�$��Center=�$��12(�$
��Wrap=�$	 Justify=��� -   $��txtThirdMeaning��$��Center=�$��Center=�$��12(�$
��Wrap=�$	 Justify=�� $��5q�
 � ColumnDefinitions
 �� $��* ��� $
��Auto ��� $��* � � RowDefinitions �� .+��� -   $��txtLastCard��$��0��$��0��$
��Left=�$��9(�	Last Card�� -   $��txtTotalCard��$��0��$��1��$��Center=�$��9(�$��12��$
��15,0q�$	��Top=�	15 card�� -   $��txtNextCard��$��0��$��2��$��Right=�$��9(�	Next Card� $
��Auto��$��5, 10, 5, 5q�
 �� �� �� �� ��  �� .+��� -   $��butFeedback5��$��22��$��22��$��0��$��0��.���� $&�� Resources/Feedback/Feedback5.png��$ Đã ghi nhớ���� -   $��butFeedback4��$��22��$��22��$��1��$��0��.���� $&�� Resources/Feedback/Feedback4.png��$ Tương đối nhớ���� -   $��butFeedback3��$��22��$��22��$��2��$��0��.���� $&�� Resources/Feedback/Feedback3.png��$ Nhớ chưa chắc chắn���� -   $��butFeedback2��$��22��$��22��$��3��$��0��.���� $&�� Resources/Feedback/Feedback2.png��$ Nhớ mang máng���� -   $��butFeedback1��$��22��$��22��$��4��$��0��.���� $&�� Resources/Feedback/Feedback1.png��$ 
Đã quên��