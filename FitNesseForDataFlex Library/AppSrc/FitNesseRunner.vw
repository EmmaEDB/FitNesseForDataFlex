Use dfallent.pkg
Use cRichEdit.pkg

Activate_View Activate_FitNesseRunner for oFitNesseRunnerView
Object oFitNesseRunnerView is a dbView
    Set Border_Style to Border_Thick
	Set Size to 200 450
    Set Location to 2 2
    Set Maximize_Icon to True
    Set Label to "DataFlex FitNesse Runner"

    Set Verify_Data_Loss_Msg to 0
    Set Verify_Exit_Msg      to 0
    Set pbAutoActivate to True
    Set Icon to "fitnesse-logo-large.ico"

    Object oDisplay is a cRichEdit
        Set Size to 180 429
        Set Location to 12 11
        Set peAnchors to anAll
    End_Object

    Procedure DisplayLine String sLine
        Send AppendTextLn to oDisplay sLine
    End_Procedure
End_Object
