Add-PSSnapin citrix*
New-PSDrive -name cgp -PSProvider CitrixGroupPolicy -Root "" -Controller localhost 
$GPNamesPath="c:\Programdata\GPNames.xml"
$GPTreePath="c:\Programdata\GPTree.xml"
$PolicyConfigPath="c:\Programdata\GPConfig.xml"

Function Generate-PolicyTree
{
 
    $GP=@(get-ChildItem -path cgp:\user\Unfiltered\settings -recurse | ?{$_.psobject.Properties.name.Contains("State")})
    $GP+= @(get-ChildItem -path cgp:\computer\Unfiltered\settings -recurse | ?{$_.psobject.Properties.name.Contains("State")})
    $GP|select PSPath | export-clixml $GPTreePath
}

Function Get-GPHsTable
{  
    if(-not (Test-Path $GPTreePath))
    {
        throw "do not find the GPTree file"
    }
    if(-not (Test-Path $GPNamesPath))
    {
        throw "do not find the GPNames file"
    }
    $GPTree=import-clixml $GPTreePath
    $GPNames=import-clixml $GPNamesPath
    $ReturnPolicyArray=@()
    foreach($eachName in $GPNames)
    {
        foreach($eachGPTreeNode in $GPTree)
        {
            $path = $eachGPTreeNode.PSPath.Remove(0,45).replace("Unfiltered",$eachName.Name)
            $eachGP= Get-Item -path $eachGPTreeNode.PSPath.Remove(0,45)
            $ConfGPItem = Get-Item -path $path
            $UserContext = "User"
            if($path.Contains("Computer"))
            {
                $UserContext="Computer"
            }
            if($ConfGPItem.State -ne $eachGP.State)
            {
                $GPHt=@{GPName=[string]($eachName.name);UserContext=$UserContext;PolicyName=[string]($eachGP.PSChildName);State="";Value=""}
                if(($ConfGPItem.psobject.Properties.name.Contains("Value")) -and ($ConfGPItem.value -ne ""))
                {
                    $GPHt.Value=[string]($ConfGPItem.value)
                }
                elseif(($ConfGPItem.psobject.Properties.name.Contains("Values")) -and ($ConfGPItem.values[0] -ne ""))
                {
                    $GPHt.Value=[string]($ConfGPItem.values[0])
                }
                else 
                {
                    $GPHt.State=[string]($ConfGPItem.State)
                }
                $ReturnPolicyArray+=$GPHt
            }
        }
    }
    return $ReturnPolicyArray 

}

Function Get-GPNames
{
    if(Test-Path $GPNamesPath)
    {
        remove-item $GPNamesPath -force
    }
    $GPItems = @(get-ChildItem -path cgp:\user | ?{$_.name -ne "Unfiltered"})
    $returnArray = @()
    $GPItems | %{
        $tmp=@{Name=$_.Name;Priority=$_.Priority;Description=$_.Description}
        $returnArray+=$tmp
    }
    $GPItems = @(get-ChildItem -path cgp:\computer | ?{$_.name -ne "Unfiltered" })
    $GPItems | %{
        foreach($each in $returnArray)
        {
            if($each.Name -ne $_.Name)
            {
                $tmp=@{Name=$_.Name;Priority=$_.Priority;Description=$_.Description}
                $returnArray+=$tmp
            }
        }
    }
    $returnArray | export-clixml $GPNamesPath
    return $returnArray 
}