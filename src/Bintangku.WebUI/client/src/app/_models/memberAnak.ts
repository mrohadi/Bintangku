import { Photo } from './photo';

export interface MemberAnak {
  id: number;
  namaLengkap: string;
  nik: number;
  jenisKelaminAnak: string;
  tanggalLahirAnak: Date;
  alamat: string;
  kontak: string;
  jumlahSaudara: number;
  photoAnakUrl: string;
  beratBadan: number;
  panjangLahir: number;
  apgarScore: number;
  kelahiranDibantuOleh: string;
  lainLain: string;
  namaAyah: string;
  tanggalLahirAyah: Date;
  pekerjaanAyah: string;
  namaIbu: string;
  tanggalLahirIbu: Date;
  pekerjaanIbu: string;
  penghasilanOrangTua: number;
  anggotaRumahTangga: number;
  tandaTanganOrangTua: string;
  namaNakes: string;
  nakesPhoto: Photo[];
}
