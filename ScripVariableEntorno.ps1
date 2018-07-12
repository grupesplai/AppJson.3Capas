
if (Test-Path 'env:VUELING_HOME3') 
{ 
    "Variable de entorno VUELING_HOME ya existente:"
    Get-Childitem env:VUELING_HOME
} 
else 
{
    [Environment]::SetEnvironmentVariable('VUELING_HOME3', 'C:\Users\G1\Documents', 'User')
    "Nueva variable de entorno VUELING_HOME2 creada correctamente"
}


"http://www.itprotoday.com/management-mobility/powershell-one-liner-creating-and-modifying-environment-variable"
"https://ss64.com/ps/syntax-env.html"