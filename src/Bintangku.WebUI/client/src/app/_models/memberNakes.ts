import { Photo } from './photo';

export interface MemberNakes {
  id: number;
  username: string;
  fullName: string;
  gender: string;
  age: number;
  noStrTenagaKesehatan: number;
  tempatPelayanan: string;
  phoneNumber: string;
  createdAt: Date;
  lastActive: Date;
  photoUrl: string;
  photos: Photo[];
}
