   M S B A M L   `   `   `  ����E  AUIControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:UIControls;assembly=UIControls
UIControls  5       DiccionarioJuridicoV22   ,DiccionarioJuridicoV2.AddUpdates.AddGenerico   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      C
UIControls,clr-namespace:UIControls;assembly=UIControls     5      m iTelerik.Windows.Controls.Docking, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7j fTelerik.Windows.Controls.Data, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.RibbonView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n	 jTelerik.Windows.Controls.GridView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a
 ]Telerik.Windows.Data, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.Navigation, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Mtelerik1http://schemas.telerik.com/2008/xaml/presentation    	 
    5      -   5        $	��800��5      $	��500��5      $��AddUpdateGenericos��5      )  #Telerik.Windows.Controls.WindowBase    
ResizeMode$  NoResize=�5
      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��	25,29,0,0q�6   $
��Left=�5      $	��Top=�5      $��	Término:��5      $��14(�5      $
��Bold"�5      �� 5   
   $��	25,95,0,0q�6   $
��Left=�5      $	��Top=�5      $��Definición:��5      $��14(�5      $
��Bold"�5      �� 5    
   -   5         ��Name$ TxtDefinicion��5       $	��130��5!      $��25,124,25,10q�5"      $��Stretch=�5#      $	��Top=�5$       �� AcceptsReturn .  �� TextWrapping$
 Wrap=�5&      (  "Telerik.Windows.Controls.RadButton  5'   
   -   5          Name$ BtnCancelar��5'      $��2��5(      $��1��5)      $��75��5*      $��
0,0,105,10q�5+      $��Right=�5,      $��Bottom=�5-      $��Cancelar��5/        50   
   -   5        $ 
BtnGuardar��50      $��2��51      $��1��52      $��75��53      $��	0,0,25,10q�54      $��Right=�55      $��Bottom=�56      $��Guardar��58      )  #Telerik.Windows.Controls.RadListBox  5:   
   -   5          Name$ RLstDuplicados��5:      $��1��5;      $��25,60,25,80q�5<      $��Stretch=�5=      $��Stretch=�5>       �� DisplayMemberPath$ Termino��5?      ��5@      ��    UIControls.SearchTextBox  5C   
   -   5        $��
25,63,30,0q�5C   #   $��Stretch=�5D   #   $	��Top=�5E   #   $
 Wrap=�5H   #   ��5G   #   �� *	Termino+5H   #   �� 5I   
   $��1��6   $��	25,29,0,0q�5J      $
��Left=�5K      $	��Top=�5L      $��Términos similares��5M      $��14(�5N      $
��Bold"�5O      
���  ��5P      �� 5Q   
   $��1��6   $��
25,255,0,0q�5R      $
��Left=�5S      $	��Top=�5T      $��Fuente:��5U      $��14(�5V      $
��Bold"�5W      �� 5X   
   -   5        $ 	TxtFuente��5X      $��1��5Y      $	��150��5Z      $��25,290,25,10q�5[      $��Stretch=�5\      $	��Top=�5]       . $
 Wrap=�5_      5a      5b      