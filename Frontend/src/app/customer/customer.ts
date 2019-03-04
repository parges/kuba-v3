export interface Customer {
  id?: number;
  firstname: string;
  lastname: string;
  birthday?: string;
  tele: string;
  avatar?: string|any;
  reviews?: Review[];
}

export interface Review {
  id: number;
  name: string;
  date: string;
  payed: boolean;
  exercises: string;
  reasons: string;
  patientId: number;
}