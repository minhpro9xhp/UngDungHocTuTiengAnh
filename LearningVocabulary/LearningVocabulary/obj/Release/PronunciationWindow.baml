   M S B A M L   `   `   `  ���� G  CUngDungHocTu, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:UngDungHocTuUngDungHocTu  &     UngDungHocTu.PronunciationWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:UngDungHocTu       � Title$  PronunciationWindow�� � SizeToContent$ WidthAndHeight=�$	��350��$	��200��.��� -    �Name$ 
layoutRoot�� � ColumnDefinitions ��  � RowDefinitions �� $
��auto ��� �� .+��� 
�������.+�]� $��0��$��0����.  
�������$��5q�.+��� $	��Top=�&$Nhập từ cần viết phiên âm:�� -    ��Name$ textBlockWarning��$��Bottom=�
���  ��$��10(�$y�	Collapsed=�Từ không hợp lệ�� -    ��Name$ textBoxWord��$
��Left=�$
��auto��$	��270��$��0,0,5,0q��� $
��Left=�$��50��.��OK]� $��0��$��2��$��5q���.  .+��� $
��Left=�$��0,0,5,0q�Số âm tiết:�� -   $ textBlockCountSyllabes��$
��Left=��� -    ��Name$ stackPanelSyllabes�� �� Orientation$ 
Horizontal=�$��Right=�	 � 	Resources	 
 �� 
TargetType �� Property �� Value��%l   '��       �� "
 ��.���  � ��
 ������  �@��CornerRadius$ 5����  � ��$ 0,0,3,0q�.+��� 	 ��%2   '��       �� "
 ��.���  � ��$ 4,0,4,0q�._��� sample(� $��0��$��1��$	��Top=�$��5,10,5,5q� (� Stretch$
 None=�.���� -   $ stackPanelWord��$ 
Horizontal=�	 ��%�   '��       '�� ;     �� "
 ��.���  � ��
 �������  � ��$ 60(��� "
 ��.���  � ��$ 5����  � ��$ 60����  � ��
 �����.+��� Sample Text�� 