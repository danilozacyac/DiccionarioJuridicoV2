   M S B A M L   `   `   `  ����E  AUIControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:UIControls;assembly=UIControls
UIControls  5       DiccionarioJuridicoV24   .DiccionarioJuridicoV2.UserControls.RGenFigScjn   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      C
UIControls,clr-namespace:UIControls;assembly=UIControls     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      m iTelerik.Windows.Controls.Docking, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7j fTelerik.Windows.Controls.Data, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.RibbonView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n	 jTelerik.Windows.Controls.GridView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a
 ]Telerik.Windows.Data, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.Navigation, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Mtelerik1http://schemas.telerik.com/2008/xaml/presentation    	 
    5      -   5        .��5      �   � ColumnDefinitions  5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   )  #Telerik.Windows.Controls.RadListBox  -   5          Name$ RLstGenericos��5      $��10,50,10,20q�5      $��Stretch=�5      $��Stretch=�5       �� DisplayMemberPath$ Termino��5      $��16(�5      >  8Telerik.Windows.Controls.Primitives.ItemsControlSelector   SelectedValuePath$ 
IdGenerico��5      ��5      �� 5      � 5   
   $��1��6    � RowDefinitions 5      �� 5      $��* �6    �� 5      $��* �6    �� 5      $��50 �6    .+�5"      � $��0��6    5#      �� 5$      $��30 �6$   �� 5%      $��30 �6$   �� 5&      $��* �6$   .+�5(      �� $��0��6   $��10,0,0,0q�5)      $
��Left=�5*      $	��Top=�5+      $��Figuras jurídicas��5,      $��14(�5-      $
��Bold"�5.        50      -   5        $ RLstFiguras��50   %   $��2��51   %   $��10q�52   %   $��Stretch=�53   %   $��Stretch=�54   %   $��14(�55   %   ��56   %   �� ��57      �� 58      .R�59      �   5:   "   �� 5;   &   $��2* �67   �� 5<   &   $��* �67   .+�5>   "   ��  �� Orientation$ 
Horizontal=�6-   .+�5?   &   �� $��2q�6/    d� 	IsChecked 6:   �� *
IsSelected+ �� Mode$ TwoWay=��� 5@   &   $�� ��60   �� 5A   &   ��60   �� *
Concepto+5B   #   �� 5C   "   $��1��6-   $ Vertical=�6=   .+�5D   &   �� 
���  ����6A   �� *
NumTesis+ �� StringFormat$ {0} Tesis Relacionadas��5E   #   5F      5G      5I         UIControls.SearchTextBox  5K      -   5        	  Name$	 SearchConceptos��5K   +   $��1��5L   +   $	��304��5M   +   $��10,4,0,0q�5N   +   $
��Left=�5O   +   $	��Top=�5P   +   
   	LabelText$
 Buscar��5Q   +   6>   5S      � 5U      $��1��6    5V      �� 5W      $��30 �6$   �� 5X      $��30 �6$   �� 5Y      $��* �6$   .+�5]      �� $��0��6   $��20,0,0,0q�5^      $
��Left=�5_      $	��Top=�5`      $��Conceptos SCJN��5a      $��14(�5b      $
��Bold"�5c        5e      -   5        $	 
SearchScjn��5e   +   $��1��5f   +   $	��304��5g   +   $��10,4,0,0q�5h   +   $
��Left=�5i   +   $	��Top=�5j   +   $
 Buscar��5k   +   6>     5m      -   5        $ RLstScjn��5m   %   $��2��5n   %   $��10q�5o   %   $��Stretch=�5p   %   $��Stretch=�5q   %   $��14(�5r   %   ��5s   %   �� ��5t      �� 5u      .R�5v      �� $ 
Horizontal=�6)   .+�5w   "   �� $��2q�6+    66   �� *
IsSelected+$ TwoWay=��� 5x   "   $�� ��6,   �� 5y   "   ��6,   �� *ConceptoScjn+5z      5{      5}      5      (  "Telerik.Windows.Controls.RadButton  5�      -   5          Name$ RbtnGuardar��5�       $��2��5�       $	��104��5�       $��35��5�       $��0,5,10,0q�5�       $��Right=�5�       +  %Telerik.Windows.Controls.StyleManager   Theme-  'Telerik.Windows.Controls.ThemeConverter$ Expression_Dark 5�       $	��Top=�5�       $��Guardar��5�       5�      �� 5�   
   $��	10,10,0,0q�6   $
��Left=�5�      $	��Top=�5�      $ ��Términos del diccionario:��5�      $��14(�5�      $
��Bold"�5�      5�      5�      