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

  toFormGroup(questionsChapterOne: FormBase<any>[]) {
    let group: any = {};

    questionsChapterOne.forEach(question => {
      group[question.key] = question.required ? new FormControl(question.value || '', Validators.required)
                                              : new FormControl(question.value || '');
    });
    // questionsChapterTwo.forEach(question => {
    //   group[question.key] = question.required ? new FormControl(question.value || '', Validators.required)
    //                                           : new FormControl(question.value || '');
    // });
    return new FormGroup(group);
  }

  getTestung ( patientId: number ): Promise<Testung> {
    // const params = new HttpParams()
    // .set('patientId', patientId.toString())
    return this.$http.get<Testung>( environment.globalEndpoint + 'Testung/'+ patientId )
               .toPromise();
  }
  // TODO: get from a remote source of question metadata
  // TODO: make asynchronous
  getQuestionsChapterOne(_item: Testung) {
    
    let _questions: FormBase<any>[] = [];
    _item.questions.forEach(question => {
      _questions.push(
        new RadioQuestion({
          key: question.id,
          label: question.data.name,
          type: 'radio',
          options: DEFAULT_OPTIONS
        })
      );
      
    });
    // let questions: FormBase<any>[] = [
      
    //   // new Chapter({
    //   //   value: "I. TESTS ZUR ÜBERPRÜFUNG DER GROBMOTORISCHEN KOORDINAION UND DES GLEICHGEWICHT"
    //   // }),
    //   new RadioQuestion({
    //     key: 'q-1-1',
    //     label: 'Aufrichten aus Rückenlage in den Stand',
    //     type: 'radio',
    //     options: DEFAULT_OPTIONS
    //   }),
    //   new RadioQuestion({
    //     key: 'q-1-2',
    //     label: 'Aufrichten aus Bauchlage in den Stand',
    //     type: 'radio',
    //     options: DEFAULT_OPTIONS
    //   }),
    //   new RadioQuestion({
    //     key: 'q-1-3',
    //     label: 'Romberg Test (Augen geöffnet)',
    //     type: 'radio',
    //     options: DEFAULT_OPTIONS
    //   }),
    //   new RadioQuestion({
    //     key: 'q-1-4',
    //     label: 'Romberg Test (Augen geöffnet)',
    //     type: 'radio',
    //     options: DEFAULT_OPTIONS
    //   })
    // ];
    return _questions.sort((a, b) => a.order - b.order);
  }
  // TODO: get from a remote source of question metadata
  // TODO: make asynchronous
  getQuestionsChapterTwo() {
 
    let questions: FormBase<any>[] = [
      
      new Chapter({
        value: "II. TESTS ZUR MOTORISCHEN ENTWICKLUNG"
      }),
      new RadioQuestion({
        key: 'q-2-1',
        label: 'Kriechen auf dem Bauch',
        type: 'radio',
        options: DEFAULT_OPTIONS
      })
    ];
    return questions.sort((a, b) => a.order - b.order);
  }
}