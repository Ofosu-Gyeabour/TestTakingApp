<RadzenPanelMenu Style="width:100%">
    <RadzenPanelMenuItem Text="Dashboard" Path="@BuildPath("")" Icon="dashboard">
    </RadzenPanelMenuItem>

    <RadzenPanelMenuItem Text="Training" Icon="build">        
        <RadzenPanelMenuItem Text="Employees" Icon="article" Visible="@hasPermission("employee", "read")">
            <RadzenPanelMenuItem Text="Take Training" Path="@BuildPath("employees/trainings")" Icon="post_add"></RadzenPanelMenuItem>
        </RadzenPanelMenuItem>

        <RadzenPanelMenuItem Text="Management" Icon="article" Visible="@hasPermission("manager", "read")">
            <RadzenPanelMenuItem Text="Maintain Training" Path="@BuildPath("trainings/maintain")" Icon="input"></RadzenPanelMenuItem>
            <RadzenPanelMenuItem Text="Reports" Path="@BuildPath("trainings/report")" Icon="post_add"></RadzenPanelMenuItem>
        </RadzenPanelMenuItem>
    </RadzenPanelMenuItem>

    <RadzenPanelMenuItem Text="Assessments" Icon="payment">
        <RadzenPanelMenuItem Text="Employees" Icon="assessment" Visible="@hasPermission("employee", "read")">
            <RadzenPanelMenuItem Text="Take Assessment" Path="@BuildPath("employees/assessment")" Icon="post_add"></RadzenPanelMenuItem>
            <RadzenPanelMenuItem Text="View Results" Path="@BuildPath("assessments/employeeresults")" Icon="list"></RadzenPanelMenuItem>
        </RadzenPanelMenuItem>
        <RadzenPanelMenuItem Text="Management" Icon="article" Visible="@hasPermission("manager", "read")">
            <RadzenPanelMenuItem Text="Create Assessment" Path="@BuildPath("assessments/create")" Icon="check_circle"></RadzenPanelMenuItem>
            <RadzenPanelMenuItem Text="Maintain Assessment" Path="@BuildPath("assessments/maintain")" Icon="input"></RadzenPanelMenuItem>
            <RadzenPanelMenuItem Text="Assessment Report" Path="@BuildPath("assessments/report")" Icon="post_add"></RadzenPanelMenuItem>
            <RadzenPanelMenuItem Icon="spellcheck" Text="Questions">
                <RadzenPanelMenuItem Text="Upload Questions" Path="@BuildPath("assessment/questions/upload")" Icon="file_upload"></RadzenPanelMenuItem>
            </RadzenPanelMenuItem>
        </RadzenPanelMenuItem>
    </RadzenPanelMenuItem>
</RadzenPanelMenu>