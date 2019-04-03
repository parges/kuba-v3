export interface Review
{
    id: number | null;
    name: string;
    date: Date | string;

    /*
      * Review Overview
      */
    payed: boolean;
    exercises: string;
    reasons: string;
    /*
      * Review Details
      */
    observationsParents: string;
    observationsChild: string;
    exerciseAccomplishment: string;
    problemHierarchies: ProblemHierarchie[];
    chapters: ReviewChapter[];

    patientId: number | null;

}

export interface ProblemHierarchie
{
    Id: number | null;
    initialValue: string;
    changedValue: string;

    ReviewId: number | null;

}

export interface ReviewChapter
{
    Id: number | null;
    Name: string;
    Score: number | null;

    Questions: ReviewQuestion[];

    ReviewId: number | null;
}

export interface ReviewQuestion
{
    Id: number | null;
    Type: string;
    Label: string;
    Value: string;

    ReviewChapterId: number | null;
}
