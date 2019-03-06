export interface Customer {
  id?: number;
  firstname: string;
  lastname: string;
  birthday?: string;
  tele: string;
  address: string;
  avatar?: string|any;
  anamneseDate: string;
  anamnesePayed: boolean;
  diagnostikDate: string;
  diagnostikPayed: boolean;
  elternDate: string;
  elternPayed: boolean;
  problemHierarchy: string;
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