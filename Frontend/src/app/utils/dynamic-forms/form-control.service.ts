import { ChapterForm } from './form-task-chapter';
import { environment } from './../../../environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Chapter } from './form-chapter';
import { RadioQuestion } from './form-task-radio';
import { FormBase } from './form-base';
import { Injectable }   from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Testung } from 'src/app/models/testung';

const DEFAULT_OPTIONS = [
  {key: '0',  value: '0'},
  {key: '0,5',  value: '12,5'},
  {key: '1',  value: '25'},
  {key: '1,5',  value: '27,5'},
  {key: '2',  value: '50'},
  {key: '2,5',  value: '62,5'},
  {key: '3',  value: '75'},
  {key: '3,5',  value: '82,5'},
  {key: '4',  value: '100'}
];

@Injectable()
export class FormControlService {
  constructor(private $http: HttpClient) { }

  toFormGroup(questions: FormBase<any>[]) {
    let group: any = {};

    questions.forEach(question => {
      group[question.key] = question.required ? new FormControl(question.value || '', Validators.required)
                                              : new FormControl(question.value || '');
    });
    return new FormGroup(group);
  }

  getTestungForPatient ( patientId: number ): Promise<Testung> {
    return this.$http.get<Testung>( environment.globalEndpoint + 'Testung/' + patientId )
               .toPromise();
  }

  getFormEntries(item: Testung) {
      let entries: FormBase<any>[] = [];
      item.chapters.forEach(chapter => {
        entries.push(
          new ChapterForm({
            key: 'chapter_' + chapter.id,
            label: chapter.name
            // value: (question.value !== '') ? true : false
          })
        );
        chapter.questions.forEach(question => {
            entries.push(
              new RadioQuestion({
                key: 'question_' + question.id,
                label: question.label,
                options: DEFAULT_OPTIONS,
                // value: (question.value !== '') ? true : false
              })
            );
        });
      });
      return entries.sort((a, b) => a.order - b.order);
    }
}
