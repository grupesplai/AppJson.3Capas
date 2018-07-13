
Function Mostrar-MensajeCuadroDialogo {
    Param
    (
    [string]$Mensaje, 
    [string]$Titulo, 
    [System.Windows.Forms.MessageBoxButtons]$Botones, 
    [System.Windows.Forms.MessageBoxIcon]$Icono
    )
    return [System.Windows.Forms.MessageBox]::Show($Mensaje, $Titulo, $Botones, $Icono)
}
if (Test-Path 'env:VUELING_HOME') 
{ 
    "Variable de entorno VUELING_HOME ya existente:"
    Get-Childitem env:VUELING_HOME
} 
else 
{
    [Environment]::SetEnvironmentVariable('VUELING_HOME', 'C:\Users\G1\Documents', 'User')
    Mostrar-MensajeCuadroDialogo -Mensaje "Nueva variable de entorno VUELING_HOME creada correctamente" -Titulo "Información" -Botones OK -Icono Information
}



"http://www.itprotoday.com/management-mobility/powershell-one-liner-creating-and-modifying-environment-variable"
"https://ss64.com/ps/syntax-env.html"