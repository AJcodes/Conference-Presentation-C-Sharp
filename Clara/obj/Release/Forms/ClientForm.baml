   M S B A M L   `   `   `  ���� @  <Clara, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Clara.ControlsClara.Controls      Clara.Forms.ClientForm   %Coreclr-namespace:Clara.Controls  W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     
�������  � 	Resources     WhiteHeader �� Orientation �� EndPoint �� 
StartPoint � Color � Offset " SelectButtonColumnDataTemplate��%Q  &	        &	 �     �� .R��� $ 
Horizontal=�$��-5,-5,-5,-5q�$	��300������ $ 0.5,1&�$ 0.5,0&�.��� $ White��$ 1Q�� $ White��$	 0.5Q�� $ White��$	 0.5Q�.+��� $��10,10,10,10q�$��Center=�$��18(�
���   ����� �� .R��� $
��Join��-   $��Join Now��
���   �$	��Top=�
�������.��� .+�%   Clara.Controls.DragScrollViewer  -     Name$ 
DragScroll��$	��400��$
��Left=�$��0,0,0,0q�   DragEverywhere . $��Disabled=�$��Disabled=�.��� -    �Name$ GamesContainer��
���Gc��.+��� $	��Top=�$��Center=�$��0,40,0,0q�$��29(�
�������$��Kinect Conference Client��$
��Bold"��� $	��Top=�
�������$��40,170,40,0q��� $	��Top=�$��
40,130,0,0q�$��26(�
�������$��User Details:���� $	��Top=�$��
40,180,0,0q�$��20(�
�������$��	Username:���� -   $
��user��$	��Top=�$
��Left=�$��150,180,0,0q�$��20(�
�������$	��200���� $	��Top=�$��
40,220,0,0q�$��20(�
�������$��IP Address:���� -   $��IP��$	��Top=�$
��Left=�$��150,220,0,0q�$��20(�
�������$	��200���� $
��Left=�$	��Top=�$��
40,290,0,0q�
�������$��2q�._��� -   $��Search��$��4q�$��
Search Now��
�������$��DemiBold"�$��24(�  -   $ DragScroll2��$��Stretch=�$��400,121,0,0q� . $��Disabled=�$��Disabled=�.��� -   $ GamesContainer2��.+��� -	   $��sessions������ 	 �� 
TargetType"	 ��.��� 
 �� Property
 � �� �� Value$ 28���� 
 � ��$ 18(��� 
 � �� �	#5EF4E057�� 
 � ��
 �   � �� Triggers P�  P� Property �@J�IsMouseOver P� Value . . ��� 
 � ��
 ��  ��� 
 � �� �� $ 0.5,1&�$ 0.5,0&�.��� $ 	#FFFFC704��$ 0.986Q�� $ 	#FFF4E057��$	 0.5Q�� $ 	#FFF4E057��$
 0.51Q����� $ 0.939,0.919&�$ 0.061,0.081&�.��� $ 	#FFFFE07E��$ 0Q�� $ 	#FFFFFAEA��$ 1Q� �� View ��  �� ColumnHeaderTemplate# [  .P��� $��Presentation Name�� �� DisplayMemberBinding �� *Col1+�� $��Author�� �� *Col2+��  �� Width$	 100��$
��Port�� �� *Col3+�� $��Action�� �� CellTemplate# [ � -
   $��canvas��$	��Top=�$��	400,0,0,0q�$	��121��.+��� $��
20,20,0,70q�$
��Left=�$��22(�$��Search for Session��$
��Bold"��� -   $��mainmenu��$��	20,85,0,0q�$
��Left=�$��19(�$��	Main Menu���� $��Stretch=�$��	0,120,0,0q�
���   ��� -   $��Close��$��20��$��0,0,10,0q�$	��Top=�$��Right=�$*��$/Clara;component/Resources/close.png���� -   $��Minimize��$��20��$��0,0,35,0q�$	��Top=�$��Right=�$-��'/Clara;component/Resources/minimize.png��