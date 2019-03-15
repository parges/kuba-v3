export class Testung
{
    id?: number;
    name: string;
    date: Date | string;
    questions: TestungDetails[];
    patientId: number | null;
    /*Patient: Patient;*/

}

export interface TestungDetails
{
    id: number | null;
    data: TestungBaseData;
    value: string;

    testungId: number | null;

}

export interface TestungBaseData
{
    id: number | null;
    name: string;

    testungChapterId: number | null;

}

export interface TestungBaseChapter
{
    id: number | null;
    name: string;

}