# Job seeker assistant

## About

The purpose of this app is to help you manage your job seeking activities. Features:

<ul>
    <li>Create a personal account</li>
    <li>Upload your resume</li>
    <li>Generate AI-powered application letters</li>
    <li>AI-powered interview practice</li>
</ul>

## API documentation

### IDENTITY

| PATH         | METHOD | REQUEST     | RESPONSE   | RESPONSE CODE |
| ------------ | ------ | ----------- | ---------- | ------------- |
| /login       | POST   | LoginDto    | Cookie     | 200, 404, 400 |
| /logout      | POST   | {}          |            | 200           |
| /register    | POST   | RegisterDto |            | 200, 400      |
| /user/roles  | GET    | Cookie      | UserRole[] | 200, 404      |
| /manage/info | GET    | Cookie      | ?          | 200, 404      |

### RESUME

| PATH                 | METHOD | REQUEST                 | RESPONSE | RESPONSE CODE |
| -------------------- | ------ | ----------------------- | -------- | ------------- |
| /resume/all/{userId} | GET    | string userId           | Resume[] | 200, 401      |
| /resume/{resumeId}   | GET    | string resumeId         | Resume   | 200, 404, 401 |
| /resume              | POST   | Resume                  |          | 200, 404, 401 |
| /resume/{resumeId}   | PUT    | string resumeId, Resume |          | 200, 401      |
| /resume/{resumeId}   | DELETE | string resumeId, Resume |          | 200, 401      |

### APPLICATION LETTER

| PATH                        | METHOD | REQUEST                           | RESPONSE | RESPONSE CODE |
| --------------------------- | ------ | --------------------------------- | -------- | ------------- |
| /letter/generate/{resumeId} | POST   | string resumeId, PromptRequestDto | Letter   | 200, 401      |
| /letter/{letterId}          | GET    | string letterId                   | Letter   | 200, 404, 401 |
| /letter/all/{userId}        | GET    | string userId                     | Letter   | 200, 404, 401 |
| /letter/{letterId}          | PUT    | string letterId, Letter           |          | 200, 401      |
| /letter/{letterId}          | DELETE | string letterId                   |          | 200, 401      |

## Entities & DTOs

| NAME                                   | PROPERTIES                                                                                                                           |
| -------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------ |
| LoginDto                               | string username, string password                                                                                                     |
| RegisterDto                            | string email, string password                                                                                                        |
| JobDto                                 | string CompanyName, string About, string JobDescription                                                                              |
| PromptRequestDto                       | string language, JobDto                                                                                                              |
| GptDto                                 | string model, gptMessageDto[] Messages                                                                                               |
| GptMessageDto                          | string role, string content                                                                                                          |
| ResumeWorkItem                         | string CompanyName, string title, int yearsOfExperience, string description                                                          |
| ResumeEducationItem                    | string school, int years, string degree, description, string program                                                                 |
| Resume                                 | string id, string name, string aboutMe, string[] skills, string[] languages , ResumeWorkItem[], ResumeEducationItem[], string UserId |
| Letter                                 | string id, string title, string Text, string UserId                                                                                  |
| User : IdentityUser                    | string Name, IdentityUserClaim[], IdentityUserLogin[], IdentityUserToken[], ApplicationUserRole[],                                   |
| ApplicationRole : IdentityRole         | ApplicationUserRole[]                                                                                                                |
| ApplicationUserRole : IdentityUserRole | ApplicationRole[]                                                                                                                    |
