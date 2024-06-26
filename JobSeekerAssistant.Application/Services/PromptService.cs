using JobSeekerAssistant.Application.Interfaces.Services;
using JobSeekerAssistant.Domain.Dtos;
using JobSeekerAssistant.Domain.Entities;

namespace JobSeekerAssistant.Application.Services;

public class PromptService : IPromptService
{
    public async Task<string> GeneratePromptForLetterAsync(JobDto job, Resume resume, string language)
    {
        var prompt = $"Hej! Jag vill att du läser in följande information om mig och det företag jag tänkt söka jobb hos. " +
                     $"Utgå från denna information och skriv en ett personligt brev som jag kan använda vid mig ansökan. " +
                     $"Det är väldigt viktigt att du funderar noggrant på hur du formulerar dig. Jag vill att du formulerar" +
                     $" dig på ett sätt som känns avslappnat och naturligt. \n" +
                     $" Här kommer en kort beskrivning av mig:\n {resume.AboutMe} \n" +
                     $"Här kommer en lista med färdigheter som jag besitter: \n";

        foreach (var skill in resume.Skills)
        {
            prompt += $"* {skill} \n";
        }

        prompt += "Här kommer en lista över alla språk som jag behärskar: \n";
        foreach (var lang in resume.Languages)
        {
            prompt += $"* {lang}\n";
        }

        prompt +=
            $"Här kommer en lista som innehåller mina arbetslivserfarenheter tillsammans" +
            $" med kort information om vad jag gjorde på respektive arbetsplats: \n";

        foreach (var workItem in resume.WorkItems)
        {
            prompt += $"* Arbetsplats: {workItem.CompanyName}. Roll: {workItem.Title}. Antal år i tjänsten: {workItem.YearOfExperience}. " +
                      $"Beskrivning av min tjänst: {workItem.Description} \n\n";
        }

        prompt +=
            $"Här kommer en lista över min utbildningsbakgrund: \n";

        foreach (var education in resume.EducationItems)
        {
            prompt += $"* Skola: {education.School}. Program: {education.Program}. Examen: {education.Degree}. Utbildningens längd: {education.Years}. " +
                      $"Beskrivning av utbildningen: {education.Description} \n\n";
        }

        prompt += $"Här kommer information om min tjänsten som jag söker: \n" +
                  $"Företagets namn: {job.CompanyName} \n\n" +
                  $"Här kommer platsannonsen:\n {job.JobDescription} \n\n" +
                  $"Här kommer information om företaget: \n {job.About}\n\n" +
                  $"Som sagt vill jag att du med utgångspunkt i information som du har fått skräddarsyr ett personligt brev där mina kompetenser " +
                  $"på ett tydligt sätt matchas med företagets värdegrund och det som efterfrågas i platsannonsen. Det ska tydligt framgå " +
                  $"på vilket sätt jag vore en bra kandidat för tjänsten. Jag vill också att mitt personliga brev ger en motivation till varför " +
                  $"jag vill vara hos just dem.\n" +
                  $"Fundera gärna flera gånger på hur ett personligt brev bäst skulle kunna formuleras, och när du har tänkt ut den bästa möjliga" +
                  $" versionen vill jag att du svarar mig. Jag vill även att mitt personliga brev skrivs på {language}";


        return prompt;
    }
}