   M S B A M L   `   `   `  ���� G  CUngDungHocTu, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:UngDungHocTuUngDungHocTu      UngDungHocTu.ManageWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:UngDungHocTu     -     � Title$  
Quản lý��$	��500��$	��800�� � 
ResizeMode$ NoResize=�.��� -    �Name$ 
layoutRoot�� � ColumnDefinitions �� $
��2.5* ���  � RowDefinitions �� $��20 ��� .+�� $��0��$��0��
�������.+�]� ��.  .+�o� $
��Left=�.@�m� $�� _File��.@�m� $
��_New��m� -   $��_Import Database��m� $��_Export Database��.@�m� -   $��_*.xml��m� $��_*.xlsx (MS Excel)��$y�	Collapsed=�m� $��_*.docx (MS Word)��$y�	Collapsed=��� m� -   $��_Exit�� m� InputGestureText$ Alt + F4��m� $��_Tools��.@�m� $(��"_Lọc từ mới trong văn bản��m� -   $��_Setting��m� $��_Help��.@�m� $��_Help Contents��m� $��
_Tutorials���� m� $��
_Home Page��m� $��_Contact Support���� m� $��_Check for updates...���� m� -   $��_About��m� $��_Tell a friend���� $��0��$��1�� K� ZIndex$ 1�� �� Orientation$ 
Horizontal=�$��Right=�$	��Top=�$��20��$��0,4,6,0q�.+�]� .+��� -    ��Name$ findingButton��$��Right=�$��5,0,0,0q�.��Tìm�� -	   	 ��Name$	 findingTextBox��$��Right=�$	��150���� $��1��$��0��$ 1��$��Bottom=�$��Right=�$��20��$��	0,0,23,13q�.+��� -
   $ butAlphabeticalOrder��$��0,0,5,0q�
������ $��0q�.���� -   
 ��Name$
 butAlphabeticalOrder_icon��$+��%Resources/Buttons/ascending_order.png�� � ToolTip$ Sắp xếp thứ tự���� -    ��Name$ tabControlCard�� �� SelectedIndex$ 0��$��0��$��1��$��5q�.@��� -    ��Name$ tabItemLearningCard��$��Từ đang học��.���  �� �� $
��auto �.+��� $��0��.���� -    ��Name$ stackPanelLearningCard��$ Vertical=� � 	Resources  �� 
TargetType �� Property �� Value��%G  '��       '�� M     '�� �     '�� �     �� " ��.���  �@��Orientation$ 
Horizontal=���  � ��$ 10q��� " ��.���  � ��$	 Top=���  � ��$ 5,5,5,0q���  � ��$ 50����  � ��$ 1q���  � ��
 ������� " ��.���  � ��$ Bottom=��� " ��.���  � ��$ 5,0,10,0q�.+��� ._��� .+��� $��22(�
Superman�� 
�������$��20,0,0,3q�/pronunciation/�� 
�������$��25,0,0,3q�*(1. First Meaning 2. Second Meaning 3....�� �� ._��� .+��� $��22(�
Aqua Man�� 
�������$��20,0,0,3q�/pronunciation/�� 
�������$��25,0,0,3q�*(1. First Meaning 2. Second Meaning 3....�� �� ._��� .+��� $��22(�Wonder Woman�� 
�������$��20,0,0,3q�/pronunciation/�� 
�������$��25,0,0,3q�*(1. First Meaning 2. Second Meaning 3....�� ]� $��1����.  .+��� -    ��Name$  textBlockLearningCardCount��$
��Left=��� -   $ tabItemUnlearnedCard��$��Từ chưa học��.���  �� �� $
��auto �.+��� $��0��.���� -   $ stackPanelUnlearnedCard��$ Vertical=� ��%/  '��       '�� M     '�� �     '�� �     �� " ��.���  �@��Orientation$ 
Horizontal=���  � ��$ 10q��� " ��.���  � ��$	 Top=���  � ��$ 5,5,5,0q���  � ��$ 50����  � ��$ 1q��� " ��.���  � ��$ Bottom=��� " ��.���  � ��$ 5,0,10,0q�.+��� ._��� .+��� $��22(�
Superman�� 
�������$��20,0,0,3q�/pronunciation/�� 
�������$��25,0,0,3q�*(1. First Meaning 2. Second Meaning 3....�� �� ._��� .+��� $��22(�
Aqua Man�� 
�������$��20,0,0,3q�/pronunciation/�� 
�������$��25,0,0,3q�*(1. First Meaning 2. Second Meaning 3....�� �� ._��� .+��� $��22(�Wonder Woman�� 
�������$��20,0,0,3q�/pronunciation/�� 
�������$��25,0,0,3q�*(1. First Meaning 2. Second Meaning 3....�� ]� $��1��.+��� -   $! textBlockUnlearnedCardCount��$
��Left=�CSDL:�� -   $ tabItemLearnedCard��$��Từ đã học��.���  �� �� $
��auto �.+��� $��0��.���� -   $ stackPanelLearnedCard��$ Vertical=� ��%/  '��       '�� M     '�� �     '�� �     �� " ��.���  �@��Orientation$ 
Horizontal=���  � ��$ 10q��� " ��.���  � ��$	 Top=���  � ��$ 5,5,5,0q���  � ��$ 50����  � ��$ 1q��� " ��.���  � ��$ Bottom=��� " ��.���  � ��$ 5,0,10,0q�.+��� ._��� .+��� $��22(�
Superman�� 
�������$��20,0,0,3q�/pronunciation/�� 
�������$��25,0,0,3q�*(1. First Meaning 2. Second Meaning 3....�� �� ._��� .+��� $��22(�
Aqua Man�� 
�������$��20,0,0,3q�/pronunciation/�� 
�������$��25,0,0,3q�*(1. First Meaning 2. Second Meaning 3....�� �� ._��� .+��� $��22(�Wonder Woman�� 
�������$��20,0,0,3q�/pronunciation/�� 
�������$��25,0,0,3q�*(1. First Meaning 2. Second Meaning 3....�� ]� $��1��.+��� -   $ textBlockLearnedCardCount��$
��Left=�CSDL:� $��0��$��1��
�������.+��� $��Center=�$��Center=�$��13(�Bảng chỉnh sửa� $��1��$��1��
������� �� $
��auto ��� $
��auto �.+�� $��0��$	��Top=�$��5q� �� �� .+��� -   $ stackPanelEditCard��$��0��$��5q�{�.  .+���  J� 	AllowDrop .  �� SelectionMode$ Single=�$y�	Collapsed=�.@��� $��Từ đang học���� $��Từ chưa học���� $��Từ đã học��]� .+��� $	��Top=�Từ:�� -   $	 textBoxEditWord��]� .+��� $	��Top=�Phiên âm:�� -   $ butPronunciationWindow��$y�Visible=�$��Bottom=�$��0,5,0,0q�$	��150��.��Công cụ gõ phiên âm�� -   $	 textBoxEditPronunciation��$
��Left=��� $
��Auto=�$	��230��$��	0,0,0.4,0q�.����  ��%2   ']�       �� " ]�.���  � ��$ 0,5,0,5q�.+�]� .+��� $	��Top=�Nghĩa thứ 1:�� -   $	 textBoxEditFirstMeaning��$	��Top=��� $	��Top=�VD:�� -   $	 textBoxEditFirstExample��]� .+��� $	��Top=�Nghĩa thứ 2:�� -   $	 textBoxEditSecondMeaning��$	��Top=��� $	��Top=�VD:�� -   $	 textBoxEditSecondExample��]� .+��� $	��Top=�Nghĩa thứ 3:�� -   $	 textBoxEditThirdMeaning��$	��Top=��� $	��Top=�VD:�� -   $	 textBoxEditThirdExample��� $��1��$	��Top=�$��Center=�$��20��$��0,8,0,0q�.+�]� -     ]�Name$ dockPanelEditCard��$y�	Collapsed=�.+��� -!   $ butSaveCard��$��0,0,5,0q�$��45��.��Save�� -"   $ butCancelSaveCard��$��0,0,35,0q�$��45��.��Cancel�� -#   $ 	butDelete��$��20��$ Xóa từ này��.���� $"��Resources/Buttons/delete.png��]� -$   $ dockPanelCreateCard��$y�	Collapsed=�.+��� -%   $ butCreateNewCard��$��0,0,20,0q�$��45��.��Tạo�� -&   $ butCancelCreateNewCard��$��45��.��
Hủy bỏ]� -'   $ dockPanelNewCard��$y�Visible=�.+��� -(   $ 
butNewCard��.��Tạo mới