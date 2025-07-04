import { Dialog, DialogContent, DialogFooter, DialogHeader, DialogTitle } from "@/components/ui/dialog";
import { Button } from "@/components/ui/button";

type Props = {
  open: boolean;
  onCancel: () => void;
  onConfirm: () => void;
};

export default function ConfirmDeleteDialog({ open, onCancel, onConfirm }: Props) {
  return (
    <Dialog open={open} onOpenChange={onCancel}>
      <DialogContent>
        <DialogHeader>
          <DialogTitle>Удалить сотрудника?</DialogTitle>
        </DialogHeader>
        <DialogFooter>
          <Button variant="outline" onClick={onCancel}>Отмена</Button>
          <Button variant="destructive" onClick={onConfirm}>Удалить</Button>
        </DialogFooter>
      </DialogContent>
    </Dialog>
  );
}
