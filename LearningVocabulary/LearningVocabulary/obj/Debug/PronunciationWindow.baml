   M S B A M L   `   `   `  ����G  CUngDungHocTu, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:UngDungHocTuUngDungHocTu  5   	   &     UngDungHocTu.PronunciationWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:UngDungHocTu     5   	     � Title$  PronunciationWindow��5   	    � SizeToContent$ WidthAndHeight=�6%   $	��350��6D   $	��200��6S   .��5	      � -   5         �Name$ 
layoutRoot��5	       � ColumnDefinitions 5
   
   �� 5       � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      �� 5      .+�5   
   �� 
�������.+�5      ]� $��0��6   $��0��6(   ��.  
�������$��5q�6b   .+�5      �� $	��Top=�6   &$Nhập từ cần viết phiên âm:6M   �� 5      -   5         ��Name$ textBlockWarning��5      $��Bottom=�66   
���  ��$��10(�6_   $y�	Collapsed=�6m   Từ không hợp lệ6�   �� 5      -   5         ��Name$ textBoxWord��5      $
��Left=�6/   $
��auto��6E   $	��270��6R   $��0,0,5,0q�6a   6�   �� 5      $
��Left=�6   $��50��6/   .��6:   OK6>   5      5      ]� 5   
   $��0��6   $��2��6$   $��5q�61   ��.  .+�5      �� $
��Left=�6   $��0,0,5,0q�6.   Số âm tiết:6L   �� 5      -   5        $ textBlockCountSyllabes��5      $
��Left=�68   6P   �� 5      -   5         ��Name$ stackPanelSyllabes��5       �� Orientation$ 
Horizontal=�65   $��Right=�6N   	 � 	Resources	 5      
 �� 
TargetType �� Property �� Value��%�   '��       �� 5       "
 ��6   .�5!      ��  � ��
 ����67   �� 5"       �@��CornerRadius$ 5��69   �� 5#       � ��$ 0,0,3,0q�63   5$      5%      .+�5&      �� 	 5'      ��%W   '��       �� 5(      "
 ��6    .�5)      ��  � ��$ 4,0,4,0q�67   5*      5+      ._�5,      �� sample6(   5-      5.      50      (� 51   
   $��0��6   $��1��6"   $	��Top=�6/   $��5,10,5,5q�6G    (� Stretch$
 None=�6Y   .��52      �� -   5        $ stackPanelWord��52      $ 
Horizontal=�61   	 53      ��%  '��       '�� n     �� 54      "
 ��6   .�55      ��  � ��
 �����67   �� 56       � ��$ 60(�65   57      �� 58      "
 ��6   .�59      ��  � ��$ 5��62   �� 5:       � ��$ 60��63   �� 5;       � ��
 �����61   5<      5=      .+�5>      �� Sample Text6)   �� 5?      6   5A      5B      5D      5E      