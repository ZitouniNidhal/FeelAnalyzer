   M S B A M L   `   `   `  ����   FeelAnalyzer    EmotionApp.MainWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Emotion Analyzer��$	��500��$	��600�����#f4f4f9 � 	Resources  �� 
TargetType �� Property �� Value3  -System.Windows.Media.Effects.DropShadowEffect   Color   	Direction   ShadowDepth   Opacity	 �� Triggers
 :� RoutedEvent �� TargetProperty	 �� To g� Duration	 W� To   
StatusText��%  '��       '��     &	  i    �� " ��.���  � ��$ 16(���  � ��$	 250����  � ��$ 50����  � �� �#4CAF50��  � ��
 �������  � ��$ 10q���  � ��$ Center=���  � ��$	 Top=���  � ��
 ���� ��  � ��$
 Bold"���  � ��$ 10q���  �@�Cursor$
 Hand����  � ��$
 Bold"���  � ��$ 1q���  �@J�Effect   $ Black��$	 270Q�$ 5Q�$	 0.4Q�	 :� $
 Button.MouseEnter��.[��� .���� .���� $1 +(Button.Background).(SolidColorBrush.Color)� #009688$ 0:0:0.3D�W� $ (Button.Width)� 260$ 0:0:0.3D�:� $
 Button.MouseLeave��.[��� .���� .���� $1 +(Button.Background).(SolidColorBrush.Color)� #4CAF50$ 0:0:0.3D�W� $ (Button.Width)� 250$ 0:0:0.3D��� " ��.���  � ��$	 400����  � ��$	 100����  � ��$ 10q���  � ��$ Center=���  � ��$	 Top=���  � ��$ 16(���  �@��TextWrapping$
 Wrap=���  � ��
 �������  � �� �#4CAF50��  � ��$ 2q���  � ��$ 10q���  �@J�Effect   $ Black��$	 270Q�$ 3Q�$	 0.3Q��� " ��.���  � ��$ 14(���  � ��$ Center=���  � ��$ Center=���  � ��
 �������  �@��Padding$ 5q�.��� .+��� $��Analyseur d'Émotions��$��36(�$
��Bold"�$��Center=�$	��Top=�$��0,20,0,0q��� -   $��AnalyzeFaceButton��$%��Analyser les Émotions Faciales��$	��Top=�$��10,100,10,0q����#008CBA�� -   $��TextInputBox��$	��100��$	��400��$��Center=�$��Center=�$��10q�$��Entrez le texte ici...���� -   $'��!Analyser les Émotions Textuelles��$��Center=�$��Bottom=�$��10,10,10,50q����#FF5733�� -   $��ResultTextBlock��#��[  $��Center=�$��Bottom=�$��
10,0,10,20q�