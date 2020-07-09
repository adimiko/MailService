$Projects = @('Core', 'Application', 'Infrastructure', 'Api')

Foreach($Project in $Projects)
{
    Write-host "Restoring dependencies for"$Project 
    $Path = '../src/' + $Project + '/' + $Project + '.csproj'
    dotnet restore $Path
    Write-host
}