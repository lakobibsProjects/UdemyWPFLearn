   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5   	   C ?NotesApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:NotesApp.ViewNotesApp.View 5   	   7 clr-namespace:NotesApp.ViewModelNotesApp.ViewModel 5   	   I)clr-namespace:NotesApp.ViewModel.CommandsNotesApp.ViewModel.Commands 5	   	   M+clr-namespace:NotesApp.ViewModel.ConvertersNotesApp.ViewModel.Converters 5
   	   G(clr-namespace:NotesApp.View.UserControlsNotesApp.View.UserControls 5   	      NotesApp.View.NoteWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   ^bPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:NotesApp.View     5   	   /vm clr-namespace:NotesApp.ViewModel     5   	   =command)clr-namespace:NotesApp.ViewModel.Commands     5	   	   :cv+clr-namespace:NotesApp.ViewModel.Converters     5
   	   7uc(clr-namespace:NotesApp.View.UserControls     5   	     � Title$  
NoteWindow��5   	   $	��400��6   $	��600��6)    � 	Resources 5         NotesApp.ViewModel.NotesVM   vm=  7NotesApp.ViewModel.Converters.BoolToVisibilityConverter  	boolToVis-  'NotesApp.ViewModel.Commands.ExitCommand  exitCommand��%W   &	        &	      &	 &       5   
   6     5   
   6'     5   
   6   5      .��5      ]� -   5         ]�Name$ 	container��5      .+�5   
   o� $	��Top=�6   .@�5      m� $
��File��6   .@�5      m� $��New Notebook��6    m� Command 5      �� *NewNotebookCommand+m� 5      $��New Note��6    5      �� *NewNoteCommand+ m� CommandParameter 5      �� *SelectedBook+�� 5      m� 5      $
��Exit��6   # [ 5      5      5       �� 5!   
   $��Bottom=�6   .@�5"      �� .��5#      �� -   5         ��Name$ statusTextBlock��5#      5$      5%      �� 5&   
   $	��140��6   
���p�$
��Left=�5*       �� SelectedItem 5(      �� *SelectedBook+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=���5+      �� *	Notebooks+$ PropertyChanged=���5,      �� 5-      .R�5.      � .+�5/      )  #NotesApp.View.UserControls.Notebook  	   DisplayNotebook	 6&   �� �� 50      ��6"   �� *Name+$ TwoWay=�$ PropertyChanged=�y�51   "   �� 
 �� Source#
 [   �� Path$ 	IsEditing� �� 	Converter# [ .��52   I   .   (System.Windows.Interactivity.Interaction   Triggers 53      /   )System.Windows.Interactivity.EventTrigger  54   "      	EventName$ 	LostFocus��61   .   (System.Windows.Interactivity.TriggerBase   Actions. 55   &   6   0System.Windows.Interactivity.InvokeCommandAction     Command 6<   �� #
 [  $ HasEditedCommand�   CommandParameter 56   <   �� 57   #   .��58   6   59       � ContextMenu 5:      �� 5;      .@�5<   "   m� $��Rename��6+    5=   +   �� #
 [  $ BeginEditCommand�m� 5>   "   $��Delete��6+    5?   +   �� #
 [  $ DeleteNotebookCommand� 5@   +   �� 5A      5C      5D      5F      �� 5G   
   $	��140��6   $
��Left=�5H       5I      �� *SelectedNote+��5J      �� *Notes+��5K      �� 5L      .R�5M      ,	  &NotesApp.View.UserControls.NoteControl	   	  Note 6%   �� .��5N      m� $��Delete��6#    5O   +   �� #
 [  $ DeleteNoteCommand� 5P   +   �� 5Q      5R      5T      `� 5U   
   $	��Top=�6   .�5V      c� .@�5W      d� -   5         d�Name$ 
boldButton��5W      .��5Y      �� $��B��6    $
��Bold"�5Z       5[      d� 5\      -   5        $ italicButton��5\      .��5^      �� $��I��6    $��Italic$�5_       5`      d� 5a      -   5        $ underlineButton��5a      .��5c      �� $��U��6    $��	Underline{�5d       5e      �� 5f      -   5         ��Name$ fontFamilyComboBox��5f      $	��100��5g      5h      �� 5i      -   5        $ fontSizeComboBox��5i      $��50��5j       �� 
IsEditable . 5l      �� 5m      -   5         ��Name$ saveFileButton��5n      $
��Save��5m      5o      5p      5q      � 5r   
    � RowDefinitions 5s      �� 5t      $
��Auto �6    �� 5u      .+�5w      �  � ColumnDefinitions 5x      �� 5y      $
��Auto �6'   �� 5z      .+�5|      �� $��Name of note: ��6   $��0��62   $��Center=�6B   $��5 0 0 0q�6]   �� 5}      $��1��5~   H   $��5 2 15 2q�6X   ��5}      �� #
 [  $ SelectedNote.Titel�$ TwoWay=�$ PropertyChanged=�5~   X   5      �� 5�      -	   5         ��Name$ contentRichTextBox��5�      $��1��5�      5�      5�      5�      5�      