import { TextareaQuestion } from './form-task-textarea';
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
const RADIO2_OPTIONS = [
  {key: 'Homolog',  value: 'Homolog'},
  {key: 'Homolateral',  value: 'Homolateral'},
  {key: 'Einseitig',  value: 'Einseitig'},
  {key: 'Desorganisiert',  value: 'Desorganisiert'},
  {key: 'Kreuzmuster',  value: 'Kreuzmuster'}
];
const RADIO3_OPTIONS = [
  {key: 'Homolog',  value: 'Homolog'},
  {key: 'Homolateral',  value: 'Homolateral'},
  {key: 'Desorganisiert',  value: 'Desorganisiert'},
  {key: 'Versetztes Kreuzmuster',  value: 'Versetztes Kreuzmuster'},
  {key: 'Kreuzmuster',  value: 'Kreuzmuster'}
];
const RADIO4_OPTIONS = [
  {key: 'abwesend',  value: 'abwesend'},
  {key: 'schwach präsent',  value: 'schwach präsent'},
  {key: 'präsent',  value: 'präsent'}
];
const RADIOYESNO_OPTIONS = [
  {key: 'Ja',  value: 'Ja'},
  {key: 'Nein',  value: 'Nein'}
];
const RADIOLEFTRIGHT_OPTIONS = [
  {key: 'Links',  value: 'Links'},
  {key: 'Rechts',  value: 'Rechts'}
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
          switch (question.type) {
            case 'radio':
              entries.push(
                new RadioQuestion({
                  key: 'question_' + question.id,
                  label: question.label,
                  options: DEFAULT_OPTIONS,
                  value: question.value
                })
              );
              break;
            case 'textarea':
              entries.push(
                new TextareaQuestion({
                  key: 'question_' + question.id,
                  label: question.label,
                  value: question.value
                })
              );
              break;
            case 'input':
              entries.push(
                new TextareaQuestion({
                  key: 'question_' + question.id,
                  label: question.label,
                  value: question.value
                })
              );
              break;
            case 'radio2':
              entries.push(
                new RadioQuestion({
                  key: 'question_' + question.id,
                  label: question.label,
                  options: RADIO2_OPTIONS,
                  value: question.value
                })
              )
              break;
            case 'radio3':
              entries.push(
                new RadioQuestion({
                  key: 'question_' + question.id,
                  label: question.label,
                  options: RADIO3_OPTIONS,
                  value: question.value
                })
              )
              break;
            case 'radio4':
              entries.push(
                new RadioQuestion({
                  key: 'question_' + question.id,
                  label: question.label,
                  options: RADIO4_OPTIONS,
                  value: question.value
                })
              )
              break;
            case 'radioYesNo':
              entries.push(
                new RadioQuestion({
                  key: 'question_' + question.id,
                  label: question.label,
                  options: RADIOYESNO_OPTIONS,
                  value: question.value
                })
              )
              break;
            case 'radioLeftRight':
              entries.push(
                new RadioQuestion({
                  key: 'question_' + question.id,
                  label: question.label,
                  options: RADIOLEFTRIGHT_OPTIONS,
                  value: question.value
                })
              )
              break;
          }

        });
      });
      return entries.sort((a, b) => a.order - b.order);
    }
}
